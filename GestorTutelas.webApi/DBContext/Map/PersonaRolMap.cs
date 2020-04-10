
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorTutelas.webApi.DBContext.Entity;

namespace GestorTutelas.webApi.DBContext.Map
{

    public class PersonaRolMap
    {
        public PersonaRolMap(EntityTypeBuilder<PersonaRolEntity> entityTypeBuilder)
        {

            entityTypeBuilder.HasKey(x => x.Id);
            entityTypeBuilder.ToTable("PersonaRol");

            entityTypeBuilder.Property(x => x.Id).HasColumnName("id")
            .HasDefaultValueSql("uuid_generate_v4()");            

        }
    }
}

