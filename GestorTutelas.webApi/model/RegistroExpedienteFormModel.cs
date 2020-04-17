using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Enums;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GestorTutelas.webApi.model
{
    public class RegistroExpedienteFormModel
    {
        public string Data { get; set; }
        public string CapchaResponse { get; set; }
        public IFormFile File_ { get; set; }

        public RegistroExpedienteModel registroExpediente(){
            try
            {
                return JsonConvert.DeserializeObject<RegistroExpedienteModel>(Data);
            }
            catch (Exception)
            {

                return null;
            }
        }


}

public class RegistroExpedienteModel
{
    public PersonaExpedienteModel Accionante { get; set; }
    public PersonaExpedienteModel Accionado { get; set; }
    public List<PersonaExpedienteModel> Intervinientes { get; set; }
    public DerechoFundamentalParametroEnum DerechoFundamental { get; set; }
    public EspecialidadParametroEnum Especialidad { get; set; }    
    public Int32 IdMunicipioRadicado { get; set; }
        public Boolean TerminosyCondiciones { get; set; }


    }

public class PersonaExpedienteModel
{
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public TipoDocumentoParametroEnum TipoDocumento { get; set; }
    public string CorreoElectronico { get; set; }
    public string Documento { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Celular { get; set; }
    public Int32? IdMunicipioResidencia { get; set; }
}

 
}