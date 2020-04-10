
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class MunicipioMap
    {
        public MunicipioMap(EntityTypeBuilder<MunicipioEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("Municipio");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id");

        }
    }
}

