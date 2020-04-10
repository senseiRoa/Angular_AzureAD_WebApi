using GestorTutelas.webApi.DBContext.Infraestructure;
using System;
using System.ComponentModel.DataAnnotations;


namespace GestorTutelas.webApi.DBContext.Entity
{
    public class RolEntity: BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Rol { get; set; }
    }

}
