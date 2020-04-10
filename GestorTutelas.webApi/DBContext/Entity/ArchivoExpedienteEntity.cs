using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class ArchivoExpedienteEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string ruta { get; set; }
        public string formato { get; set; }
        public string tamanho { get; set; }
        public string hash { get; set; }
        public string nombreCargado { get; set; }
        public string nombreAsignado { get; set; }

        public TipoArchivoParametroEnum TipoArchivo { get; set; }

        [ForeignKey("ExpedienteDigital")]
        public Guid idExpediente { get; set; }
        public virtual ExpedienteDigitalEntity ExpedienteDigital { get; set; }





    }


}
