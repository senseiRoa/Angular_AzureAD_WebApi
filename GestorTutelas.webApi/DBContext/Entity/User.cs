using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestorTutelas.webApi.DBContext.Entity
{
    public class Usuario
    {
        [Key]
        public string Id { get; set; }
        public string usuario { get; set; }
        public string contrasenha { get; set; }

    }

    public class UsuarioMap
    {
        public UsuarioMap(EntityTypeBuilder<Usuario> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("usuario");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");
            entityTypeBuilder.Property(x => x.usuario).HasColumnName("usuario");
            entityTypeBuilder.Property(x => x.contrasenha).HasColumnName("contrasenha");

        }
    }
}