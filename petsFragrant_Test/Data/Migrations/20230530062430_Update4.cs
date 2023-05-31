using Microsoft.EntityFrameworkCore.Migrations;

namespace petsFragrant_Test.Data.Migrations
{
    public partial class Update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoriesID",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoriesID",
                table: "Products",
                column: "CategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoriesID",
                table: "Products",
                column: "CategoriesID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoriesID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoriesID",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriesID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
