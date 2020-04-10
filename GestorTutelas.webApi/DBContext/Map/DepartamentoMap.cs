
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class DepartamentoMap
    {
        public DepartamentoMap(EntityTypeBuilder<DepartamentoEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("Departamento");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id");

        }
    }
}

