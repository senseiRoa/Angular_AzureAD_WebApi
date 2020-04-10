using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestorTutelas.webApi.DBContext.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class MunicipioEntity : BaseEntity
    {
        [Key]
        public Int32 Id { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Departamento")]
        public Int32 IdDepartamento { get; set; }
        public virtual DepartamentoEntity Departamento { get; set; }
    }

}