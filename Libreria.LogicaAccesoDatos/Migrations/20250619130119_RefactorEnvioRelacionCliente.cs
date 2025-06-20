using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class RefactorEnvioRelacionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailCliente",
                table: "Envios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Envios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios",
                column: "ClienteId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envios_Usuarios_ClienteId",
                table: "Envios");

            migrationBuilder.DropIndex(
                name: "IX_Envios_ClienteId",
                table: "Envios");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Envios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "EmailCliente",
                table: "Envios",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }
    }
}
