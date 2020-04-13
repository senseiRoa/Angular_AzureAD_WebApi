﻿// <auto-generated />
using System;
using GestorTutelas.webApi.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GestorTutelas.webApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:PostgresExtension:uuid-ossp", ",,")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ArchivoExpedienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("TipoArchivo")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("formato")
                        .HasColumnType("text");

                    b.Property<string>("hash")
                        .HasColumnType("text");

                    b.Property<Guid>("idExpediente")
                        .HasColumnType("uuid");

                    b.Property<string>("nombreAsignado")
                        .HasColumnType("text");

                    b.Property<string>("nombreCargado")
                        .HasColumnType("text");

                    b.Property<string>("ruta")
                        .HasColumnType("text");

                    b.Property<string>("tamanho")
                        .HasColumnType("text");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("idExpediente");

                    b.ToTable("ArchivoExpediente");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.DepartamentoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ExpedienteDigitalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("CodigoRadicado")
                        .HasColumnType("text");

                    b.Property<int>("DerechoFundamental")
                        .HasColumnType("integer");

                    b.Property<int>("Especialidad")
                        .HasColumnType("integer");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("EstadoExpediente")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaRadicado")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("IdMunicipioRadicado")
                        .HasColumnType("integer");

                    b.Property<bool>("TerminosyCondiciones")
                        .HasColumnType("boolean");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdMunicipioRadicado");

                    b.ToTable("ExpedienteDigital");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.MunicipioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Municipio");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ParametroEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("DetalleCategoria")
                        .HasColumnType("text");

                    b.Property<string>("DetalleParametro")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("integer");

                    b.Property<int>("IdParametro")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parametro");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonaEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<string>("Celular")
                        .HasColumnType("text");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("text");

                    b.Property<string>("Direccion")
                        .HasColumnType("text");

                    b.Property<string>("Documento")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int?>("IdMunicipioResidencia")
                        .HasColumnType("integer");

                    b.Property<string>("Nombres")
                        .HasColumnType("text");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.Property<int>("TipoDocumento")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("idUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdMunicipioResidencia");

                    b.HasIndex("idUsuario");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonaRolEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("idPersona")
                        .HasColumnType("uuid");

                    b.Property<Guid>("idRol")
                        .HasColumnType("uuid");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("idPersona");

                    b.HasIndex("idRol");

                    b.ToTable("PersonaRol");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonasExpedienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("idExpediente")
                        .HasColumnType("uuid");

                    b.Property<Guid>("idPersonaRol")
                        .HasColumnType("uuid");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("idExpediente");

                    b.HasIndex("idPersonaRol");

                    b.ToTable("PersonasExpediente");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ProcesoExpedienteEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<int>("EstadoExpediente")
                        .HasColumnType("integer");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("idExpediente")
                        .HasColumnType("uuid");

                    b.Property<Guid>("idPersonaRol")
                        .HasColumnType("uuid");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("idExpediente");

                    b.HasIndex("idPersonaRol");

                    b.ToTable("ProcesoExpediente");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.RolEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("Rol")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.UsuarioEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Contrasenha")
                        .HasColumnName("contrasenha")
                        .HasColumnType("text");

                    b.Property<int>("Estado")
                        .HasColumnType("integer");

                    b.Property<string>("Usuario")
                        .HasColumnName("usuario")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCrea")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioElimina")
                        .HasColumnType("text");

                    b.Property<DateTime>("fechaCreacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("fechaEdicion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("fechaEliminacion")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("usuarioModifica")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ArchivoExpedienteEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.ExpedienteDigitalEntity", "ExpedienteDigital")
                        .WithMany()
                        .HasForeignKey("idExpediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ExpedienteDigitalEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.MunicipioEntity", "MunicipioRadicado")
                        .WithMany()
                        .HasForeignKey("IdMunicipioRadicado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.MunicipioEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.DepartamentoEntity", "Departamento")
                        .WithMany()
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonaEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.MunicipioEntity", "MunicipioResidencia")
                        .WithMany()
                        .HasForeignKey("IdMunicipioResidencia");

                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.UsuarioEntity", "Usuario")
                        .WithMany()
                        .HasForeignKey("idUsuario");
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonaRolEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.PersonaEntity", "Persona")
                        .WithMany()
                        .HasForeignKey("idPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.RolEntity", "Rol")
                        .WithMany()
                        .HasForeignKey("idRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.PersonasExpedienteEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.ExpedienteDigitalEntity", "ExpedienteDigital")
                        .WithMany()
                        .HasForeignKey("idExpediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.PersonaRolEntity", "PersonaRol")
                        .WithMany()
                        .HasForeignKey("idPersonaRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestorTutelas.webApi.DBContext.Entity.ProcesoExpedienteEntity", b =>
                {
                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.ExpedienteDigitalEntity", "ExpedienteDigital")
                        .WithMany()
                        .HasForeignKey("idExpediente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestorTutelas.webApi.DBContext.Entity.PersonaRolEntity", "Encargado")
                        .WithMany()
                        .HasForeignKey("idPersonaRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
