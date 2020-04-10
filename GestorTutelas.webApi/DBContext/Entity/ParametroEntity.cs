using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;


namespace GestorTutelas.webApi.DBContext.Entity
{
    public class ParametroEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public CategoriaParametroEnum IdCategoria { get; set; }
        public Int32 IdParametro { get; set; }
        public string DetalleCategoria { get; set; }
        public string DetalleParametro { get; set; }
    }

}
