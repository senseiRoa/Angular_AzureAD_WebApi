using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestorTutelas.webApi.DBContext.Enums;
using GestorTutelas.webApi.DBContext.Infraestructure;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class PersonaEntity : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public TipoDocumentoParametroEnum TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }


        [ForeignKey("MunicipioResidencia")]
        public Int32 IdMunicipioResidencia { get; set; }
        public virtual MunicipioEntity MunicipioResidencia { get; set; }


        [ForeignKey("Usuario")]
        public Guid? idUsuario { get; set; }
        public virtual UsuarioEntity Usuario { get; set; }


    }

}