
using System;
using System.Collections.Generic;
using System.IO;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Repository.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace GestorTutelas.webApi.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class PersonaRolController : ControllerBase
    {
        private PersonaRolRepository _PersonaRolRepository;

        public PersonaRolController(PersonaRolRepository PersonaRolRepository)
        {
            this._PersonaRolRepository = PersonaRolRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._PersonaRolRepository.GetAll();
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
                var entity = this._PersonaRolRepository.Get(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Post(PersonaRolEntity entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                var response = this._PersonaRolRepository.Insert(entity);
                if (response)
                {
                    return Ok(new { status = true, message = entity });
                }
                else
                {
                    return BadRequest(new { status = false, message = "Error creando el objeto" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPut]
        public ActionResult Put(PersonaRolEntity entity)
        {
            try
            {
                var response = this._PersonaRolRepository.Update(entity);
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
                var response = this._PersonaRolRepository.Delete(id);
                return Ok(new { status = true, message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }
    }
}
