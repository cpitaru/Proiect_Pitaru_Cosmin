using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_Pitaru_Cosmin.Migrations
{
    public partial class CategorieCeai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurnizorID",
                table: "Ceai",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeCategorie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Furnizor",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeFurnizor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnizor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategorieCeai",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CeaiID = table.Column<int>(nullable: false),
                    CategorieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieCeai", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategorieCeai_Categorie_CategorieID",
                        column: x => x.CategorieID,
                        principalTable: "Categorie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorieCeai_Ceai_CeaiID",
                        column: x => x.CeaiID,
                        principalTable: "Ceai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ceai_FurnizorID",
                table: "Ceai",
                column: "FurnizorID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieCeai_CategorieID",
                table: "CategorieCeai",
                column: "CategorieID");

            migrationBuilder.CreateIndex(
                name: "IX_CategorieCeai_CeaiID",
                table: "CategorieCeai",
                column: "CeaiID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ceai_Furnizor_FurnizorID",
                table: "Ceai",
                column: "FurnizorID",
                principalTable: "Furnizor",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ceai_Furnizor_FurnizorID",
                table: "Ceai");

            migrationBuilder.DropTable(
                name: "CategorieCeai");

            migrationBuilder.DropTable(
                name: "Furnizor");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropIndex(
                name: "IX_Ceai_FurnizorID",
                table: "Ceai");

            migrationBuilder.DropColumn(
                name: "FurnizorID",
                table: "Ceai");
        }
    }
}
