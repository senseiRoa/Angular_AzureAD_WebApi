using System;
using System.ComponentModel.DataAnnotations;
using GestorTutelas.webApi.DBContext.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class UsuarioEntity: BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Usuario { get; set; }
        public string Contrasenha { get; set; }

    }

}