using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBookMVC.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Energy = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    RecipeModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredientModels_RecipeModels_RecipeModelId",
                        column: x => x.RecipeModelId,
                        principalTable: "RecipeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: true),
                    RecepieId = table.Column<string>(nullable: true),
                    IngredientModelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageModels_IngredientModels_IngredientModelId",
                        column: x => x.IngredientModelId,
                        principalTable: "IngredientModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImageModels_RecipeModels_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "RecipeModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageModels_IngredientModelId",
                table: "ImageModels",
                column: "IngredientModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageModels_RecepieId",
                table: "ImageModels",
                column: "RecepieId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientModels_RecipeModelId",
                table: "IngredientModels",
                column: "RecipeModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "IngredientModels");

            migrationBuilder.DropTable(
                name: "RecipeModels");
        }
    }
}
