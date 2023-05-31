using Microsoft.EntityFrameworkCore.Migrations;

namespace petsFragrant_Test.Data.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_CategoriesCategoryID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoriesCategoryID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryID",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "FatherCategoryID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_FatherCategoryID",
                table: "Categories",
                column: "FatherCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_FatherCategoryID",
                table: "Categories",
                column: "FatherCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_FatherCategoryID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_FatherCategoryID",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "FatherCategoryID",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoriesCategoryID",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoriesCategoryID",
                table: "Categories",
                column: "CategoriesCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_CategoriesCategoryID",
                table: "Categories",
                column: "CategoriesCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
