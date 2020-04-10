using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class ExpedienteDigitalEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DerechoFundamentalParametroEnum DerechoFundamental { get; set; }
        public EspecialidadParametroEnum Especialidad { get; set; }
        public EstadoExpedienteParametroEnum EstadoExpediente { get; set; }
        public DateTime FechaRadicado { get; set; }
        public string CodigoRadicado { get; set; }

        [ForeignKey("MunicipioRadicado")]
        public Int32 IdMunicipioRadicado { get; set; }
        public virtual MunicipioEntity MunicipioRadicado { get; set; }

    }

}
