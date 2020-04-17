import { RegistroExpedienteData, Persona } from './../../modelos/registro-expediente';

import { EspecialidadService } from 'src/app/servicios/especialidad.service.ts';
import { DerechoFundamentalService } from 'src/app/servicios/derechoFundamental.service';
import { filter } from 'rxjs/operators';

import { Component, OnInit } from '@angular/core';
import { Message, MessageService, MenuItem } from 'primeng/components/common/api';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { RegistroExpediente } from 'src/app/modelos/registro-expediente';
import { DepartamentoService } from 'src/app/servicios/departamento.service';
import { MunicipioService } from 'src/app/servicios/municipio.service';
import { ExpedienteDigitalService } from 'src/service/ExpedienteDigital.service';
@Component({
  selector: 'app-formulario-publico',
  templateUrl: './formulario-publico.component.html',
  styleUrls: ['./formulario-publico.component.scss']
})
export class FormularioPublicoComponent implements OnInit {

  activeIndex: number = 0;
  formComponent: FormGroup;
  entity: RegistroExpediente;
  municipiosAux: any;
  departamentosAux: any;
  derechoFundamentalsAux: any;
  especialidadsAux: any;
  private uploadFile: File;
  fileUploadName: string;
  displayConfirmacion = false;
  displayModal = false;


  constructor(private messageService: MessageService, private fb: FormBuilder,
    private departamentoService: DepartamentoService,
    private municipioService: MunicipioService,
    private derechoFundamentalService: DerechoFundamentalService,
    private especialidadService: EspecialidadService,
    private publicService: ExpedienteDigitalService
  ) {
  }

  ngOnInit() {
    this.inicializarEntity();
    this.buildRectiveForm();
    this.cargarData();
  }
  async cargarData() {
    try {
      const dep = await this.departamentoService.getAllAsync();
      this.departamentosAux = dep.map(i => ({ label: i.Nombre, value: i }));

      const derechoFund = await this.derechoFundamentalService.getAllAsync();
      this.derechoFundamentalsAux = derechoFund.map(i => ({ label: i.value, value: i }));

      const especialidad = await this.especialidadService.getAllAsync();
      this.especialidadsAux = especialidad.map(i => ({ label: i.value, value: i }));


    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando la data, intentelo de nuevo' });
    }
  }

  showResponse(event) {
    console.log(event);
    this.entity.capchaResponse = event.response;
  }

  buildRectiveForm() {

    this.formComponent = this.fb.group({

      // tutela
      derechoFundamental: ['', [Validators.required]],
      especialidad: ['', [Validators.required]],
      Accionante: this.fb.array([this.createItem()]),
      // Accionante: this.fb.array([this.createItem()]),
      Accionado: this.fb.array([this.createItem()]),
      Intervinientes: this.fb.array([]),
      file: ['', [Validators.required]],

    });


    this.formComponent.valueChanges.subscribe(newVal => {
      // console.log(newVal);
      console.log('formulario invalido:' + this.formComponent.invalid);
    });
  }

  addItemInterviniente(): void {
    const items = this.formComponent.get('Intervinientes') as FormArray;
    items.push(this.createItem());
    const p = {} as Persona;
    this.entity.Data.Intervinientes.push(p);
  }
  deleteItemInterviniente(index): void {
    const items = this.formComponent.get('Intervinientes') as FormArray;
    items.removeAt(index);
    this.entity.Data.Intervinientes.splice(index, 1);

  }


  createItem(): FormGroup {
    return this.fb.group({
      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      tipoDoc: ['', [Validators.required]],
      documento: ['', [Validators.required]],
      correoElectronico: ['', Validators.compose([
        Validators.required,
        Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')])],
      direccion: ['', [Validators.required]],
      telefono: ['', [Validators.required]],
      celular: ['', [Validators.required]],
      departamento: ['', [Validators.required]],
      municipio: ['', [Validators.required]]
    });
  }



  get f() {
    return this.formComponent.controls;
  }



  onChange(label: string) {
    if (typeof label === 'string') {
      //this.messageService.add({ severity: 'success', summary: label, detail: 'Via MessageService' });
    }

  }
  refresh(): void {
    window.location.reload();
  }
  async depChange() {
    try {

      const mun = await this.municipioService.getAllAsync();

      this.municipiosAux = mun.filter(i => i.id === this.entity.Data.IdDepartamentoRadicado)
        .map(i => ({ label: i.Nombre, value: i.id }));
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando los información, intentelo de nuevo' });
    }


  }

  myUploader(event) {
    // event.files == files to upload
    try {
      //  this.isbussy = true;

      const files = event.files;
      this.uploadFile = files[0];
      this.messageService.add({ severity: 'success', summary: 'Exito', detail: 'Preparando el archivo' });
      this.entity.fileName = this.uploadFile.name;
    } catch (error) {
      console.log(error.message);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: error.message });
    } finally {
      // this.isbussy = false;
    }
  }

  onClear(event) {
    this.uploadFile = null;
    this.entity.fileName = null;
    console.log(event);
  }

  terminar() {
    this.refresh();
  }

  async send(event) {
    try {

      const rta = await this.publicService.uploadFormDataAsync(this.uploadFile, this.entity);

      if (rta.status) {
        this.messageService.add({ severity: 'success', summary: 'Exito', detail: rta.message });
        // this.inicializarEntity();
        // this.uploadFile = null;
        // this.formComponent.reset();
        // this.activeIndex = 0;
        this.displayConfirmacion = true;

      } else {

        this.messageService.add({ severity: 'error', summary: 'Error', detail: rta.message });
      }
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error guardando, intentelo de nuevo' });
    }

  }
  inicializarEntity() {
    this.entity = {} as RegistroExpediente;
    this.entity.Data = {} as RegistroExpedienteData;
    this.entity.Data.Accionado = {} as Persona;
    this.entity.Data.Accionado.tipoDocAux = {};
    this.entity.Data.Accionante = {} as Persona;
    this.entity.Data.Intervinientes = [];
  }



}
