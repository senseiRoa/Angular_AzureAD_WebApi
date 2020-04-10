using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class ProcesoExpedienteEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }



        [ForeignKey("Encargado")]
        public Guid idPersonaRol { get; set; }
        public virtual PersonaRolEntity Encargado { get; set; }


        [ForeignKey("ExpedienteDigital")]
        public Guid idExpediente { get; set; }
        public virtual ExpedienteDigitalEntity ExpedienteDigital { get; set; }

        public EstadoExpedienteParametroEnum EstadoExpediente { get; set; }



    }


}
