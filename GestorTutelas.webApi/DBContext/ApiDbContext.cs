using System;
using GestorTutelas.webApi.DBContext.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestorTutelas.webApi.DBContext
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) :
        base(options)
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasPostgresExtension("uuid-ossp");
            new UsuarioMap(modelBuilder.Entity<Usuario>());

        }


    }

}
