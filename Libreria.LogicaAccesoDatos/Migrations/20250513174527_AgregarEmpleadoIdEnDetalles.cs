using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libreria.LogicaAccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarEmpleadoIdEnDetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvios_Usuarios_EmpleadoId",
                table: "DetallesEnvios");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "DetallesEnvios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmpladoId",
                table: "DetallesEnvios",
                type: "int",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvios_Usuarios_EmpleadoId",
                table: "DetallesEnvios",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEnvios_Usuarios_EmpleadoId",
                table: "DetallesEnvios");

            migrationBuilder.DropColumn(
                name: "EmpladoId",
                table: "DetallesEnvios");

            migrationBuilder.AlterColumn<int>(
                name: "EmpleadoId",
                table: "DetallesEnvios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEnvios_Usuarios_EmpleadoId",
                table: "DetallesEnvios",
                column: "EmpleadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
