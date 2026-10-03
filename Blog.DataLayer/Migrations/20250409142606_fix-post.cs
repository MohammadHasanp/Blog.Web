using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.DataLayer.Migrations
{
    public partial class fixpost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryID",
                table: "Posts",
                column: "SubCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Categories_SubCategoryID",
                table: "Posts",
                column: "SubCategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Categories_SubCategoryID",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_SubCategoryID",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "Posts");
        }
    }
}
