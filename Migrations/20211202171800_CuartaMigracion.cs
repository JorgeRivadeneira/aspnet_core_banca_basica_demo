using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBasica.Migrations
{
    public partial class CuartaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movimiento",
                columns: table => new
                {
                    Id_Movimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cuenta = table.Column<int>(type: "int", nullable: false),
                    cuentaId_Cuenta = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimiento", x => x.Id_Movimiento);
                    table.ForeignKey(
                        name: "FK_movimiento_cuenta_cuentaId_Cuenta",
                        column: x => x.cuentaId_Cuenta,
                        principalTable: "cuenta",
                        principalColumn: "Id_Cuenta",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimiento_cuentaId_Cuenta",
                table: "movimiento",
                column: "cuentaId_Cuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimiento");
        }
    }
}
