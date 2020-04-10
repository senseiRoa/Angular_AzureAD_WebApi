using System;
using System.ComponentModel.DataAnnotations;
using GestorTutelas.webApi.DBContext.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class DepartamentoEntity : BaseEntity
    {
        [Key]
        public Int32 Id { get; set; }
        public string Nombre { get; set; }

    }

}