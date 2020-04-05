using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestorTutelas.webApi.Helper;
using GestorTutelas.webApi.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
/*
ejemplo tomado de :https://dottutorials.net/dotnet-core-web-api-multipart-form-data-upload-file/
*/
namespace GestorTutelas.webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController : ControllerBase
    {


        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostFormData([FromForm]RegistroExpedienteModel registroExpendiente)
        {
            // Getting Name
            string nombre = registroExpendiente.Nombre;
            string capchaResponse = registroExpendiente.CapchaResponse;

            var response = ReCaptchaClass.Validate(capchaResponse);
            Console.WriteLine(response);
            if (Boolean.Parse(response))
            {
                // Getting Image
                var file_ = registroExpendiente.File_;
                // Saving Image on Server
                if (file_.Length > 0)
                {
                    var filePath = Path.Combine("C://uploads", file_.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file_.CopyTo(fileStream);
                    }
                }
                return Ok(new { status = true, message = "registro recibido Correctamente" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Error, la solicitud no es valida" });
            }


        }
    }
}
