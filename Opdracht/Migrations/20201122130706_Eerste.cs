using Microsoft.EntityFrameworkCore.Migrations;

namespace Opdracht.Migrations
{
    public partial class Eerste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Straatnaam = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: true),
                    BestellingId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KlantTabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Achternaam = table.Column<string>(type: "TEXT", nullable: true),
                    AdresId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    KortingCode = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlantTabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KlantTabel_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestelling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtikelNaam = table.Column<string>(type: "TEXT", nullable: true),
                    KlantId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bestelling_KlantTabel_KlantId",
                        column: x => x.KlantId,
                        principalTable: "KlantTabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "ProductBestelling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KlantId = table.Column<int>(type: "INTEGER", nullable: false),
                    BestellingId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProductId = table.Column<string>(type: "TEXT", nullable: true),
                    ProductId1 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBestelling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductBestelling_Bestelling_BestellingId",
                        column: x => x.BestellingId,
                        principalTable: "Bestelling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductBestelling_Product_ProductId1",
                        column: x => x.ProductId1,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bestelling_KlantId",
                table: "Bestelling",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_KlantTabel_AdresId",
                table: "KlantTabel",
                column: "AdresId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBestelling_BestellingId",
                table: "ProductBestelling",
                column: "BestellingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBestelling_ProductId1",
                table: "ProductBestelling",
                column: "ProductId1");

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
                name: "ProductBestelling");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Bestelling");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "KlantTabel");

            migrationBuilder.DropTable(
                name: "Adres");
        }
    }
}
