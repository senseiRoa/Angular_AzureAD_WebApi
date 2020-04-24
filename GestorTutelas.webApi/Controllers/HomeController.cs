
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
    public class HomeController : ControllerBase
    {



        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                // var entityList = this._RolRepository.GetAll();
                // return Ok(new { status = true, message = entityList });
                Console.WriteLine("Recibiendo peticion post");
                var conectionStringPostgres2 = "hola";// 

                var x = new
                {
                    val1 = Environment.GetEnvironmentVariable("hola"),
                    val2 = conectionStringPostgres2
                };
                return Ok(x);
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }



        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                // var entityList = this._RolRepository.GetAll();
                // return Ok(new { status = true, message = entityList });
                Console.WriteLine("Recibiendo peticion post");
                var conectionStringPostgres2 = "hola post";// 

                var x = new
                {
                    val1 = Environment.GetEnvironmentVariable("hola"),
                    val2 = conectionStringPostgres2
                };
                return Ok(x);
            }
            catch (Exception ex)
            {

                return BadRequest(new { status = true, message = ex.Message });
            }

        }


    }
}
