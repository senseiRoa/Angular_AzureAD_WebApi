import { FormGroup, Validators } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { Persona } from 'src/app/modelos/registro-expediente';
import { MessageService } from 'primeng/api';
import { MunicipioService } from 'src/app/servicios/municipio.service';

@Component({
  selector: 'app-persona-form',
  templateUrl: './persona-form.component.html',
  styleUrls: ['./persona-form.component.scss']
})
export class PersonaFormComponent implements OnInit {
  @Input() parentForm: FormGroup;
  @Input() entity: Persona;
  @Input() departamentosAux: any;
  @Input() form_GroupName: string;
  AccionanteForm = true;
  razonSocial = false;

  tipoDocsAux = [{ label: 'CC', value: { id: 2, value: 'CC' } }, { label: 'CE', value: { id: 3, value: 'CE' } }, { label: 'NIT', value: { id: 1, value: 'Nit' } }];
  municipiosAux: any;

  constructor(private messageService: MessageService, private municipioService: MunicipioService) { }

  get f() {
    return this.parentForm.controls;
  }
  ngOnInit() {
    console.log(this.parentForm);
    if (this.form_GroupName !== 'Accionante') {
      this.AccionanteForm = false;
      const controls = ['apellidos', 'correoElectronico', 'direccion', 'telefono', 'celular', 'departamento', 'municipio'];
      controls.forEach(c => {
        this.parentForm.get(c).clearValidators();
        this.parentForm.get(c).updateValueAndValidity();
      });
    }

  }
  onChangeTD() {

    this.entity.TipoDocumento = this.entity.tipoDocAux ? this.entity.tipoDocAux.id : null;

    if (this.entity.tipoDocAux && this.entity.tipoDocAux.value === 'Nit') {
      this.parentForm.get('apellidos').clearValidators();
      this.razonSocial = true;
    } else {
      this.parentForm.get('apellidos').setValidators([Validators.required]);
      this.razonSocial = false;
    }

    this.parentForm.get('apellidos').updateValueAndValidity();
  }
  munChange() {
    this.entity.IdMunicipioResidencia = this.entity.MunicipioAux ? this.entity.MunicipioAux.id : null;
  }
  async depChange() {
    try {

      this.entity.IdDepartamentoResidencia = this.entity.DepartamentoAux ? this.entity.DepartamentoAux.id : null;
      const mun = await this.municipioService.getAllAsync();

      this.municipiosAux = mun.filter(i => i.IdDepartamento === this.entity.DepartamentoAux.id)
        .map(i => ({ label: i.Nombre, value: i }));
    } catch (error) {
      console.log(error);
      this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Hubo un error cargando los información, intentelo de nuevo' });
    }


  }

}
