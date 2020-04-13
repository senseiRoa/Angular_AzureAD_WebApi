using Microsoft.EntityFrameworkCore.Migrations;

namespace GestorTutelas.webApi.Migrations
{
    public partial class ActualizacionEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Municipio_IdMunicipioResidencia",
                table: "Persona");

            migrationBuilder.AlterColumn<int>(
                name: "IdMunicipioResidencia",
                table: "Persona",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Persona",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TerminosyCondiciones",
                table: "ExpedienteDigital",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Municipio_IdMunicipioResidencia",
                table: "Persona",
                column: "IdMunicipioResidencia",
                principalTable: "Municipio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Municipio_IdMunicipioResidencia",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "TerminosyCondiciones",
                table: "ExpedienteDigital");

            migrationBuilder.AlterColumn<int>(
                name: "IdMunicipioResidencia",
                table: "Persona",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Municipio_IdMunicipioResidencia",
                table: "Persona",
                column: "IdMunicipioResidencia",
                principalTable: "Municipio",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
