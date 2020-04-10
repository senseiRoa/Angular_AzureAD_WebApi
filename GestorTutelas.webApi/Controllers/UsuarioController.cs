using System;
using System.Collections.Generic;
using System.IO;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Repository.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
/*
ejemplo tomado de :https://dottutorials.net/dotnet-core-web-api-multipart-form-data-upload-file/
*/
namespace GestorTutelas.webApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private UsuarioRepository usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        
        public ActionResult Get()
        {
            // Getting Name
            var rta = this.usuarioRepository.GetAll();
            return Ok(new { status = true, message = rta });


        }

        [HttpPost]
        
        public ActionResult Post(UsuarioEntity usuario)
        {
            // Getting Name
            var rta = this.usuarioRepository.Insert(usuario);
            // this.context.Add(usuario);
            // var rta = this.context.SaveChanges();
            return Ok(new { status = true, message = rta });


        }
    }
}
