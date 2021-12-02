using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBasica.Migrations
{
    public partial class _12022021_1658 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "movimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "movimiento");
        }
    }
}
