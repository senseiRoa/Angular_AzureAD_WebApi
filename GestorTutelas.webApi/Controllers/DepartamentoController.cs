
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
    public class DepartamentoController : ControllerBase
    {
        private DepartamentoRepository _DepartamentoRepository;

        public DepartamentoController(DepartamentoRepository DepartamentoRepository)
        {
            this._DepartamentoRepository = DepartamentoRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var entityList = this._DepartamentoRepository.GetAll();
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
                var entity = this._DepartamentoRepository.Get(id);
                return Ok(new { status = true, message = entity });
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }

        [HttpPost]
        public ActionResult Post(DepartamentoEntity entity)
        {
            try
            {
                
                var response = this._DepartamentoRepository.Insert(entity);
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
        public ActionResult Put(DepartamentoEntity entity)
        {
            try
            {
                var response = this._DepartamentoRepository.Update(entity);
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
                var response = this._DepartamentoRepository.Delete(id);
                return Ok(new { status = true, message = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = true, message = ex.Message });
            }

        }
    }
}
