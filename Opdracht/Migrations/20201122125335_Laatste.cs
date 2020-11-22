using Microsoft.EntityFrameworkCore.Migrations;

namespace Opdracht.Migrations
{
    public partial class Laatste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "KlantTabel",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "KortingCode",
                table: "KlantTabel",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    MakerId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    CommenterId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_KlantTabel_CommenterId",
                        column: x => x.CommenterId,
                        principalTable: "KlantTabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_KlantTabel_MakerId",
                        column: x => x.MakerId,
                        principalTable: "KlantTabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_CommenterId",
                table: "Review",
                column: "CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MakerId",
                table: "Review",
                column: "MakerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "KlantTabel");

            migrationBuilder.DropColumn(
                name: "KortingCode",
                table: "KlantTabel");
        }
    }
}
