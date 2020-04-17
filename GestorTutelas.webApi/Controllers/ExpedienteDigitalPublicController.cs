
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Repository.Implementations;
using GestorTutelas.webApi.Helper;
using GestorTutelas.webApi.model;
using GestorTutelas.webApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GestorTutelas.webApi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("pubapi/[controller]")]
    public class ExpedienteDigitalPublicController : ControllerBase
    {
        

        private ExpedienteService _ExpedienteService;

        public ExpedienteDigitalPublicController(ExpedienteService expedienteService)
        {
            this._ExpedienteService = expedienteService;
        }

        
        //     ejemplo tomado de :https://dottutorials.net/dotnet-core-web-api-multipart-form-data-upload-file/    
        [HttpPost]        
        public async Task<ActionResult> PostFormData([FromForm]RegistroExpedienteFormModel r)
        {


            string capchaResponse = r.CapchaResponse;
            string response = string.Empty;
            if (capchaResponse.Equals("3cac5401-95e3-4ea7-bfc4-cdc16a885d6b"))
            {
                response = "true";
            }
            else
            {
                response = ReCaptchaClass.Validate(capchaResponse);
            }

            if (Boolean.Parse(response))
            {
                var result=await this._ExpedienteService.guardarExpediente(r);
                return Ok(new { status = result, message = "registro recibido Correctamente" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Error, la solicitud no es valida" });
            }


        }

    }
}
