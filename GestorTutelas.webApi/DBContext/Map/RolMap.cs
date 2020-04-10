
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class RolMap
    {
        public RolMap(EntityTypeBuilder<RolEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("Rol");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");            

        }
    }
}

