using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Zpravodajstvi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mysql_11_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "CategoryID", "Description", "ImageSrc", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Popis prvního článku.", "/img/img1.jpg", "První článek" },
                    { 2, 2, "Popis druhého článku.", "/img/img2.jpg", "Druhý článek" }
                });

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "Id", "ArticleID", "TagID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 1 },
                    { 4, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Carousel",
                columns: new[] { "Id", "ImageAlt", "ImageSrc" },
                values: new object[,]
                {
                    { 1, "První článek", "/img/img1.jpg" },
                    { 2, "Druhý článek", "/img/img2.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Technologie" },
                    { 2, "Zprávy" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Zajímavé" },
                    { 2, "Inovace" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 2);

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
    }
}
