using GestorTutelas.webApi.DBContext.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GestorTutelas.webApi.DBContext.Map
{

    public class UsuarioMap
    {
        public UsuarioMap(EntityTypeBuilder<UsuarioEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("usuario");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");
            entityTypeBuilder.Property(x => x.Usuario).HasColumnName("usuario");
            entityTypeBuilder.Property(x => x.Contrasenha).HasColumnName("contrasenha");

        }
    }
}
