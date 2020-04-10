using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class PersonasExpedienteEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }




        [ForeignKey("PersonaRol")]
        public Guid idPersonaRol { get; set; }
        public virtual PersonaRolEntity PersonaRol { get; set; }


        [ForeignKey("ExpedienteDigital")]
        public Guid idExpediente { get; set; }
        public virtual ExpedienteDigitalEntity ExpedienteDigital { get; set; }



    }


}
