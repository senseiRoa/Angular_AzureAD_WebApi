using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GestorTutelas.webApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Parametro",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdParametro = table.Column<int>(nullable: false),
                    DetalleCategoria = table.Column<string>(nullable: true),
                    DetalleParametro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametro", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Rol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    usuario = table.Column<string>(nullable: true),
                    contrasenha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    IdDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpedienteDigital",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    DerechoFundamental = table.Column<int>(nullable: false),
                    Especialidad = table.Column<int>(nullable: false),
                    EstadoExpediente = table.Column<int>(nullable: false),
                    FechaRadicado = table.Column<DateTime>(nullable: false),
                    CodigoRadicado = table.Column<string>(nullable: true),
                    IdMunicipioRadicado = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedienteDigital", x => x.id);
                    table.ForeignKey(
                        name: "FK_ExpedienteDigital_Municipio_IdMunicipioRadicado",
                        column: x => x.IdMunicipioRadicado,
                        principalTable: "Municipio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    IdMunicipioResidencia = table.Column<int>(nullable: false),
                    idUsuario = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.id);
                    table.ForeignKey(
                        name: "FK_Persona_Municipio_IdMunicipioResidencia",
                        column: x => x.IdMunicipioResidencia,
                        principalTable: "Municipio",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Persona_usuario_idUsuario",
                        column: x => x.idUsuario,
                        principalTable: "usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoExpediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ruta = table.Column<string>(nullable: true),
                    formato = table.Column<string>(nullable: true),
                    tamanho = table.Column<string>(nullable: true),
                    hash = table.Column<string>(nullable: true),
                    nombreCargado = table.Column<string>(nullable: true),
                    nombreAsignado = table.Column<string>(nullable: true),
                    TipoArchivo = table.Column<int>(nullable: false),
                    idExpediente = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoExpediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_ArchivoExpediente_ExpedienteDigital_idExpediente",
                        column: x => x.idExpediente,
                        principalTable: "ExpedienteDigital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonaRol",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    idRol = table.Column<Guid>(nullable: false),
                    idPersona = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaRol", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonaRol_Persona_idPersona",
                        column: x => x.idPersona,
                        principalTable: "Persona",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaRol_Rol_idRol",
                        column: x => x.idRol,
                        principalTable: "Rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonasExpediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    idPersonaRol = table.Column<Guid>(nullable: false),
                    idExpediente = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonasExpediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_PersonasExpediente_ExpedienteDigital_idExpediente",
                        column: x => x.idExpediente,
                        principalTable: "ExpedienteDigital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonasExpediente_PersonaRol_idPersonaRol",
                        column: x => x.idPersonaRol,
                        principalTable: "PersonaRol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcesoExpediente",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    idPersonaRol = table.Column<Guid>(nullable: false),
                    idExpediente = table.Column<Guid>(nullable: false),
                    EstadoExpediente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcesoExpediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProcesoExpediente_ExpedienteDigital_idExpediente",
                        column: x => x.idExpediente,
                        principalTable: "ExpedienteDigital",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcesoExpediente_PersonaRol_idPersonaRol",
                        column: x => x.idPersonaRol,
                        principalTable: "PersonaRol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoExpediente_idExpediente",
                table: "ArchivoExpediente",
                column: "idExpediente");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedienteDigital_IdMunicipioRadicado",
                table: "ExpedienteDigital",
                column: "IdMunicipioRadicado");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_IdDepartamento",
                table: "Municipio",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_IdMunicipioResidencia",
                table: "Persona",
                column: "IdMunicipioResidencia");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_idUsuario",
                table: "Persona",
                column: "idUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRol_idPersona",
                table: "PersonaRol",
                column: "idPersona");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaRol_idRol",
                table: "PersonaRol",
                column: "idRol");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasExpediente_idExpediente",
                table: "PersonasExpediente",
                column: "idExpediente");

            migrationBuilder.CreateIndex(
                name: "IX_PersonasExpediente_idPersonaRol",
                table: "PersonasExpediente",
                column: "idPersonaRol");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesoExpediente_idExpediente",
                table: "ProcesoExpediente",
                column: "idExpediente");

            migrationBuilder.CreateIndex(
                name: "IX_ProcesoExpediente_idPersonaRol",
                table: "ProcesoExpediente",
                column: "idPersonaRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArchivoExpediente");

            migrationBuilder.DropTable(
                name: "Parametro");

            migrationBuilder.DropTable(
                name: "PersonasExpediente");

            migrationBuilder.DropTable(
                name: "ProcesoExpediente");

            migrationBuilder.DropTable(
                name: "ExpedienteDigital");

            migrationBuilder.DropTable(
                name: "PersonaRol");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
