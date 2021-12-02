using Microsoft.EntityFrameworkCore.Migrations;

namespace BancaBasica.Migrations
{
    public partial class _12022021_1224 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "cuenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "cuenta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
