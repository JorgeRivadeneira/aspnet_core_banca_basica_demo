using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBasica.Migrations
{
    public partial class _12022021_1258 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cuenta_cliente_clienteId",
                table: "cuenta");

            migrationBuilder.DropForeignKey(
                name: "FK_movimiento_cuenta_cuentaId_Cuenta",
                table: "movimiento");

            migrationBuilder.DropIndex(
                name: "IX_movimiento_cuentaId_Cuenta",
                table: "movimiento");

            migrationBuilder.DropIndex(
                name: "IX_cuenta_clienteId",
                table: "cuenta");

            migrationBuilder.DropColumn(
                name: "cuentaId_Cuenta",
                table: "movimiento");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "cuenta");

            migrationBuilder.AddColumn<int>(
                name: "Id_Cuenta",
                table: "movimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Cliente",
                table: "cuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Cuenta",
                table: "movimiento");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "cuenta");

            migrationBuilder.AddColumn<int>(
                name: "cuentaId_Cuenta",
                table: "movimiento",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clienteId",
                table: "cuenta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_cuentaId_Cuenta",
                table: "movimiento",
                column: "cuentaId_Cuenta");

            migrationBuilder.CreateIndex(
                name: "IX_cuenta_clienteId",
                table: "cuenta",
                column: "clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_cuenta_cliente_clienteId",
                table: "cuenta",
                column: "clienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movimiento_cuenta_cuentaId_Cuenta",
                table: "movimiento",
                column: "cuentaId_Cuenta",
                principalTable: "cuenta",
                principalColumn: "Id_Cuenta",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
