using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBasica.Migrations
{
    public partial class _12022021_1221 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_Cuenta",
                table: "movimiento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Cuenta",
                table: "movimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
