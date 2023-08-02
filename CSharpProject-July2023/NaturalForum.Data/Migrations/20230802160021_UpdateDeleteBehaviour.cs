using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NaturalForum.Data.Migrations
{
    public partial class UpdateDeleteBehaviour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArticles_Articles_ArticleId",
                table: "UserArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArticles_Articles_ArticleId",
                table: "UserArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserArticles_Articles_ArticleId",
                table: "UserArticles");

            migrationBuilder.AddForeignKey(
                name: "FK_UserArticles_Articles_ArticleId",
                table: "UserArticles",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
