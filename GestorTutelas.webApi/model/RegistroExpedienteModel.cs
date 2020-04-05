using Microsoft.AspNetCore.Http;
using System;


namespace GestorTutelas.webApi.model
{
    public class RegistroExpedienteModel
    {
        public string Nombre { get; set; }
        public string CapchaResponse { get; set; }
        public IFormFile File_ { get; set; }


    }
}