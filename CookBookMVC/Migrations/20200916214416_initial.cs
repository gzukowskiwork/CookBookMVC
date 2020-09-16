using Microsoft.EntityFrameworkCore.Migrations;

namespace CookBookMVC.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeModels",
                columns: table => new
                {
                    RecipeId = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeModels", x => x.RecipeId);
                });

            migrationBuilder.CreateTable(
                name: "ImageRecipes",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    RecipeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRecipes", x => new { x.ImageId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_ImageRecipes_ImageModels_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageModels",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageRecipes_RecipeModels_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "RecipeModels",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientModels",
                columns: table => new
                {
                    IngredientId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Energy = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientModels", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_IngredientModels_RecipeModels_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "RecipeModels",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageIngredients",
                columns: table => new
                {
                    ImageId = table.Column<string>(nullable: false),
                    IngredientId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageIngredients", x => new { x.ImageId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_ImageIngredients_ImageModels_ImageId",
                        column: x => x.ImageId,
                        principalTable: "ImageModels",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImageIngredients_IngredientModels_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "IngredientModels",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientCount",
                columns: table => new
                {
                    RecipeCountId = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: true),
                    IngredientId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientCount", x => x.RecipeCountId);
                    table.ForeignKey(
                        name: "FK_IngredientCount_IngredientModels_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "IngredientModels",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageIngredients_IngredientId",
                table: "ImageIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageRecipes_RecipeId",
                table: "ImageRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientCount_IngredientId",
                table: "IngredientCount",
                column: "IngredientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageIngredients");

            migrationBuilder.DropTable(
                name: "ImageRecipes");

            migrationBuilder.DropTable(
                name: "IngredientCount");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "IngredientModels");

            migrationBuilder.DropTable(
                name: "RecipeModels");
        }
    }
}
