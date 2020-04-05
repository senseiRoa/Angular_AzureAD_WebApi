
import { EspecialidadService } from 'src/app/servicios/especialidad.service.ts';
import { DerechoFundamentalService } from 'src/app/servicios/derechoFundamental.service';
import { filter } from 'rxjs/operators';

import { Component, OnInit } from '@angular/core';
import { Message, MessageService, MenuItem } from 'primeng/components/common/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegistroExpediente } from 'src/app/modelos/registro-expediente';
import { DepartamentoService } from 'src/app/servicios/departamento.service';
import { MunicipioService } from 'src/app/servicios/municipio.service';
import { DemoPublicService } from 'src/service/DemoPublic.service';
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




  constructor(private messageService: MessageService, private fb: FormBuilder,
    private departamentoService: DepartamentoService,
    private municipioService: MunicipioService,
    private derechoFundamentalService: DerechoFundamentalService,
    private especialidadService: EspecialidadService,
    private publicService: DemoPublicService
  ) {
  }

  ngOnInit() {
    this.entity = {} as RegistroExpediente;
    this.buildRectiveForm();
    this.cargarData();
  }
  async cargarData() {
    try {
      const dep = await this.departamentoService.getAllAsync();
      this.departamentosAux = dep.map(i => ({ label: i.NOMDEPTO, value: i.CODDEPTO }));

      const derechoFund = await this.derechoFundamentalService.getAllAsync();
      this.derechoFundamentalsAux = derechoFund.map(i => ({ label: i.value, value: i.id }));

      const especialidad = await this.especialidadService.getAllAsync();
      this.especialidadsAux = especialidad.map(i => ({ label: i.value, value: i.id }));


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
      nombres: ['', [Validators.required]],
      apellidos: ['', [Validators.required]],
      correoElectronico: ['', Validators.compose([
        Validators.required,
        Validators.pattern('[a-zA-Z0-9.-_]{1,}@[a-zA-Z.-]{2,}[.]{1}[a-zA-Z]{2,}')])],
      direccion: ['', [Validators.required]],
      telefono: ['', [Validators.required]],
      celular: ['', [Validators.required]],
      departamento: ['', [Validators.required]],
      municipio: ['', [Validators.required]],
      // tutela
      derechoFundamental: ['', [Validators.required]],
      especialidad: ['', [Validators.required]],
      accionante: ['', [Validators.required]],
      accionado: ['', [Validators.required]],
      intervinientes: ['', [Validators.required]],


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

  async depChange() {
    try {
      const mun = await this.municipioService.getAllAsync();

      this.municipiosAux = mun.filter(i => i.CODDEPTO === this.entity.departamento)
        .map(i => ({ label: i.NOMMUNICIP, value: i.CODMUNICIP }));
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

    } catch (error) {
      console.log(error.message);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: error.message });
    } finally {
      // this.isbussy = false;
    }
  }

  onClear(event) {
    this.uploadFile = null;
    console.log(event);
  }


  async send(event) {
    try {
      const rta = await this.publicService.uploadFormDataAsync(this.uploadFile, this.entity);

      if (rta.status) {
        this.messageService.add({ severity: 'success', summary: 'Exito', detail: rta.message });
        this.entity = {} as RegistroExpediente;
        this.uploadFile = null;
        this.formComponent.reset();
        this.activeIndex = 0;
      } else {

        this.messageService.add({ severity: 'error', summary: 'Error', detail: rta.message });
      }
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error guardando, intentelo de nuevo' });
    }

  }



}
