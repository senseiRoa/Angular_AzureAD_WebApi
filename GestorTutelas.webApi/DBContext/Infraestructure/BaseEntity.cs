using GestorTutelas.webApi.DBContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorTutelas.webApi.DBContext.Infraestructure
{
    public class BaseEntity
    {
        public EstadoRegistroEnum Estado { get; set; }
        public DateTime fechaCreacion { get; set; }
        public string UsuarioCrea { get; set; }
        public DateTime fechaEdicion { get; set; }
        public string usuarioModifica { get; set; }
        public DateTime? fechaEliminacion { get; set; }
        public string UsuarioElimina { get; set; }
    }
}
