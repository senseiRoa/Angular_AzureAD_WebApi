using System;
using GestorTutelas.webApi.DBContext.Entity;
using GestorTutelas.webApi.DBContext.Map;
using Microsoft.EntityFrameworkCore;

namespace GestorTutelas.webApi.DBContext
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) :
        base(options)
        {

        }
        
        
        public DbSet<ArchivoExpedienteEntity> ArchivoExpedienteEntities { get; set; }
        public DbSet<DepartamentoEntity> DepartamentoEntities { get; set; }
        public DbSet<ExpedienteDigitalEntity> ExpedienteDigitalEntities { get; set; }
        public DbSet<MunicipioEntity> MunicipioEntities { get; set; }
        public DbSet<ParametroEntity> ParametroEntities { get; set; }
        public DbSet<PersonaEntity> PersonaEntities { get; set; }
        public DbSet<PersonaRolEntity> PersonaRolEntities { get; set; }
        public DbSet<PersonasExpedienteEntity> PersonasExpedienteEntities { get; set; }
        public DbSet<ProcesoExpedienteEntity> ProcesoExpedienteEntities { get; set; }
        public DbSet<RolEntity> RolEntities { get; set; }
        public DbSet<UsuarioEntity> UsuarioEntities { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");
            new ArchivoExpedienteMap(modelBuilder.Entity<ArchivoExpedienteEntity>());
            new DepartamentoMap(modelBuilder.Entity<DepartamentoEntity>());
            new ExpedienteDigitalMap(modelBuilder.Entity<ExpedienteDigitalEntity>());
            new MunicipioMap(modelBuilder.Entity<MunicipioEntity>());
            new ParametroMap(modelBuilder.Entity<ParametroEntity>());
            new PersonaMap(modelBuilder.Entity<PersonaEntity>());
            new PersonaRolMap(modelBuilder.Entity<PersonaRolEntity>());
            new PersonasExpedienteMap(modelBuilder.Entity<PersonasExpedienteEntity>());
            new ProcesoExpedienteMap(modelBuilder.Entity<ProcesoExpedienteEntity>());
            new RolMap(modelBuilder.Entity<RolEntity>());
            new UsuarioMap(modelBuilder.Entity<UsuarioEntity>());

        }


    }

}
