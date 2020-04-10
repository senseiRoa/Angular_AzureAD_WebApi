
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class ExpedienteDigitalMap
    {
        public ExpedienteDigitalMap(EntityTypeBuilder<ExpedienteDigitalEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("ExpedienteDigital");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");            

        }
    }
}

