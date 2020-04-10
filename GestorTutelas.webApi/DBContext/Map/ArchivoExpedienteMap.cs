
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class ArchivoExpedienteMap
    {
        public ArchivoExpedienteMap(EntityTypeBuilder<ArchivoExpedienteEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("ArchivoExpediente");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");            

        }
    }
}

