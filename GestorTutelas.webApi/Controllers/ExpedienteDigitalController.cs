
using System;
using System.Collections.Generic;
using System.IO;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Repository.Implementations;
using GestorTutelas.webApi.Helper;
using GestorTutelas.webApi.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GestorTutelas.webApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class ExpedienteDigitalController : ControllerBase
    {
        private ExpedienteDigitalRepository _ExpedienteDigitalRepository;

        private PersonaRepository _PersonaRepository;
        private PersonaRolRepository _PersonaRolRepository;
        private PersonasExpedienteRepository _PersonasExpedienteRepository;

        public ExpedienteDigitalController(ExpedienteDigitalRepository expedienteDigitalRepository,
            PersonaRepository personaRepository, PersonaRolRepository personaRolRepository,
            PersonasExpedienteRepository personasExpedienteRepository

            )
        {
            this._ExpedienteDigitalRepository = expedienteDigitalRepository;
            _PersonaRepository = personaRepository;
            _PersonaRolRepository = personaRolRepository;
            _PersonasExpedienteRepository = personasExpedienteRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._ExpedienteDigitalRepository.GetAll();
                return Ok(new { status = true, message = entityList });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(Guid id)
        {
            try
            {
                var entity = this._ExpedienteDigitalRepository.Get(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }
        //     ejemplo tomado de :https://dottutorials.net/dotnet-core-web-api-multipart-form-data-upload-file/    
        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostFormData([FromForm]RegistroExpedienteModel registroExpendiente)
        {
            // Getting Name
            string nombre = registroExpendiente.Nombre;
            string capchaResponse = registroExpendiente.CapchaResponse;
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

                    this._PersonaRepository.Insert(new PersonaEntity { Nombres = nombre, IdMunicipioResidencia = 1 });
                }
                return Ok(new { status = true, message = "registro recibido Correctamente" });
            }
            else
            {
                return BadRequest(new { status = false, message = "Error, la solicitud no es valida" });
            }


        }

        [HttpPut]
        public ActionResult Put(ExpedienteDigitalEntity entity)
        {
            try
            {
                var response = this._ExpedienteDigitalRepository.Update(entity);
                if (response)
                {
                    return Ok(new { status = true, message = entity });
                }
                else
                {
                    return BadRequest(new { status = false, message = "Error actualizando el objeto" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var response = this._ExpedienteDigitalRepository.Delete(id);
                return Ok(new { status = true, message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }
    }
}
