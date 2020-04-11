using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorTutelas.webApi.Migrations
{
    public partial class InitialCreateBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "usuario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Rol",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "Rol",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "Rol",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Rol",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "Rol",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "Rol",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "Rol",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ProcesoExpediente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "ProcesoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "ProcesoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "ProcesoExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "ProcesoExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "ProcesoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "ProcesoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "PersonasExpediente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "PersonasExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "PersonasExpediente",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "PersonasExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "PersonasExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "PersonasExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "PersonasExpediente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "PersonaRol",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "PersonaRol",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "PersonaRol",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "PersonaRol",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "PersonaRol",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "PersonaRol",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "PersonaRol",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Persona",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Persona",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "Persona",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Municipio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "Municipio",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "Municipio",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Municipio",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "Municipio",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "Municipio",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "Municipio",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ExpedienteDigital",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "ExpedienteDigital",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "ExpedienteDigital",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "ExpedienteDigital",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "ExpedienteDigital",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "ExpedienteDigital",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "ExpedienteDigital",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Departamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "Departamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "Departamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "Departamento",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ArchivoExpediente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCrea",
                table: "ArchivoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioElimina",
                table: "ArchivoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaCreacion",
                table: "ArchivoExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEdicion",
                table: "ArchivoExpediente",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEliminacion",
                table: "ArchivoExpediente",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usuarioModifica",
                table: "ArchivoExpediente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "ProcesoExpediente");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "PersonasExpediente");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "PersonaRol");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "Municipio");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "ExpedienteDigital");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioCrea",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "UsuarioElimina",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaCreacion",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEdicion",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "fechaEliminacion",
                table: "ArchivoExpediente");

            migrationBuilder.DropColumn(
                name: "usuarioModifica",
                table: "ArchivoExpediente");
        }
    }
}
