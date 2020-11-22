using Microsoft.EntityFrameworkCore.Migrations;

namespace Opdracht.Migrations
{
    public partial class Tweede : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Straat",
                table: "Adres",
                newName: "Straatnaam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Straatnaam",
                table: "Adres",
                newName: "Straat");
        }
    }
}
