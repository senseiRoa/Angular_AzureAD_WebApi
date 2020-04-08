using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestorTutelas.webApi.DBContext;
using GestorTutelas.webApi.DBContext.Entity;
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
    public class UsuarioController : ControllerBase
    {

        private ApiDbContext context;

        public UsuarioController(ApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Get()
        {
            // Getting Name
            var rta = this.context.Usuarios.ToList();
            return Ok(new { status = true, message = rta });


        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Post(Usuario usuario)
        {
            // Getting Name
            this.context.Add(usuario);
            var rta = this.context.SaveChanges();
            return Ok(new { status = true, message = rta });


        }
    }
}
