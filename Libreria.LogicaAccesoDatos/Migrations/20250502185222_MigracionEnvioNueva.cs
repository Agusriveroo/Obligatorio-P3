using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class MigracionEnvioNueva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Envios");

            migrationBuilder.RenameColumn(
                name: "emailCliente",
                table: "Envios",
                newName: "EmailCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailCliente",
                table: "Envios",
                newName: "emailCliente");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Envios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
