using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class PersonaRolEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Rol")]
        public Guid idRol { get; set; }
        public virtual RolEntity Rol { get; set; }

        [ForeignKey("Persona")]
        public Guid idPersona { get; set; }
        public virtual PersonaEntity Persona { get; set; }



    }


}
