import { filter } from 'rxjs/operators';

import { Component, OnInit } from '@angular/core';
import { Message, MessageService, MenuItem } from 'primeng/components/common/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RegistroExpediente } from 'src/app/modelos/registro-expediente';
import { DepartamentoService } from 'src/app/servicios/departamento.service';
import { MunicipioService } from 'src/app/servicios/municipio.service';
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




  constructor(private messageService: MessageService, private fb: FormBuilder,
    private departamentoService: DepartamentoService,
    private municipioService: MunicipioService

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
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error, intentelo de nuevo' });
    }
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


    });
  }
  get f() {
    return this.formComponent.controls;
  }

  async  save() {
    try {

    } catch (error) {
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error registrandose, por favor intentelo de nuevo' });
    }

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
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error, intentelo de nuevo' });
    }


  }
}
