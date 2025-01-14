using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Zpravodajstvi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _14_fix_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "Id", "ArticleID", "TagID" },
                values: new object[,]
                {
                    { 7, 4, 3 },
                    { 8, 4, 6 },
                    { 9, 5, 4 },
                    { 10, 5, 8 },
                    { 11, 6, 1 },
                    { 12, 6, 5 },
                    { 13, 7, 2 },
                    { 14, 7, 6 },
                    { 15, 8, 3 },
                    { 16, 8, 9 },
                    { 17, 9, 4 },
                    { 18, 9, 8 },
                    { 19, 10, 1 },
                    { 20, 10, 5 },
                    { 21, 11, 2 },
                    { 22, 11, 7 },
                    { 23, 12, 3 },
                    { 24, 12, 6 },
                    { 25, 13, 1 },
                    { 26, 13, 5 },
                    { 27, 14, 2 },
                    { 28, 14, 8 },
                    { 29, 15, 4 },
                    { 30, 15, 6 },
                    { 31, 16, 1 },
                    { 32, 16, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleID",
                table: "ArticleTag",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagID",
                table: "ArticleTag",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryID",
                table: "Article",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_CategoryID",
                table: "Article",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Article_ArticleID",
                table: "ArticleTag",
                column: "ArticleID",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleTag_Tag_TagID",
                table: "ArticleTag",
                column: "TagID",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_CategoryID",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Article_ArticleID",
                table: "ArticleTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ArticleTag_Tag_TagID",
                table: "ArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTag_ArticleID",
                table: "ArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_ArticleTag_TagID",
                table: "ArticleTag");

            migrationBuilder.DropIndex(
                name: "IX_Article_CategoryID",
                table: "Article");

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
