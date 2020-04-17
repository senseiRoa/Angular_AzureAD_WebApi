export interface RegistroExpediente {
  capchaResponse: string;
  Data: RegistroExpedienteData;
  fileName: string;
}


export interface RegistroExpedienteData {
  Accionante: Persona;
  Accionado: Persona;
  Intervinientes: Persona[];
  DerechoFundamental: number;
  Especialidad: number;
  IdMunicipioRadicado: number;
  IdDepartamentoRadicado: number;
  TerminosyCondiciones: boolean;

  DerechoFundamentalAux: any;
  EspecialidadAux: any;
}

export interface Persona {
  Nombres: string;
  Apellidos: string;
  TipoDocumento: number;
  Documento: string;
  Direccion: string;
  Telefono: string;
  Celular: string;
  IdMunicipioResidencia: number;
  IdDepartamentoResidencia: number;
  CorreoElectronico: string;

  ////////////////////////////
  tipoDocAux: any;
  MunicipioAux: any;
  DepartamentoAux: any;

}
