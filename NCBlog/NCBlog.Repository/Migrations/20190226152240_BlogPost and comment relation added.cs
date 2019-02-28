using Microsoft.EntityFrameworkCore.Migrations;

namespace NCBlog.Repository.Migrations
{
    public partial class BlogPostandcommentrelationadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPosts_PostComments_PostCommentId",
                table: "BlogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPosts_PostCommentId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PostCommentId",
                table: "BlogPosts");

            migrationBuilder.DropColumn(
                name: "PostContentId",
                table: "BlogPosts");

            migrationBuilder.AddColumn<int>(
                name: "BlogPostId",
                table: "PostComments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_BlogPostId",
                table: "PostComments",
                column: "BlogPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostComments_BlogPosts_BlogPostId",
                table: "PostComments",
                column: "BlogPostId",
                principalTable: "BlogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComments_BlogPosts_BlogPostId",
                table: "PostComments");

            migrationBuilder.DropIndex(
                name: "IX_PostComments_BlogPostId",
                table: "PostComments");

            migrationBuilder.DropColumn(
                name: "BlogPostId",
                table: "PostComments");

            migrationBuilder.AddColumn<int>(
                name: "PostCommentId",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostContentId",
                table: "BlogPosts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogPosts_PostCommentId",
                table: "BlogPosts",
                column: "PostCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPosts_PostComments_PostCommentId",
                table: "BlogPosts",
                column: "PostCommentId",
                principalTable: "PostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
