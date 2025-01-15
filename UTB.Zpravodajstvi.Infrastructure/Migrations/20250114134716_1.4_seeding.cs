using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UTB.Zpravodajstvi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class _14_seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "Carousel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryID", "Description", "Title" },
                values: new object[] { 2, "Výzkumný tým Fakulty technologické UTB dosáhl významného úspěchu v oblasti vývoje biodegradabilních polymerů. Projekt získal mezinárodní uznání na konferenci v Berlíně.", "UTB získala prestižní ocenění za výzkum v oblasti polymerů" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryID", "Description", "Title" },
                values: new object[] { 3, "Fakulta multimediálních komunikací prezentovala práce studentů na mezinárodním Design Week. Projekty se zaměřily na udržitelný design a sociální inovace.", "Studenti designu představili inovativní projekty na Design Week" });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "CategoryID", "Description", "ImageSrc", "Title" },
                values: new object[,]
                {
                    { 3, 7, "Fakulta aplikované informatiky otevřela moderní centrum pro výzkum umělé inteligence a kybernetické bezpečnosti. Centrum nabídne studentům špičkové vybavení.", "/img/img1.jpg", "Nové technologické centrum otevřeno na FAI" },
                    { 4, 6, "UTB hostila významnou mezinárodní konferenci zaměřenou na udržitelný rozvoj a zelené technologie. Účastnili se odborníci z celého světa.", "/img/img2.jpg", "Mezinárodní konference o udržitelném rozvoji na UTB" },
                    { 5, 4, "Reprezentanti UTB získali několik medailí na Českých akademických hrách. Vynikajících výsledků dosáhli zejména v atletice a plavání.", "/img/img1.jpg", "Sportovci UTB zazářili na Univerzitních hrách" },
                    { 6, 1, "Fakulta managementu a ekonomiky představuje nový studijní program zaměřený na digitální transformaci podniků a průmysl 4.0.", "/img/img2.jpg", "Nový studijní program: Digitální transformace" },
                    { 7, 5, "Tradiční studentský festival přinesl do ulic Zlína kulturu, umění a zábavu. Akce přilákala tisíce návštěvníků.", "/img/img1.jpg", "Studentský festival oživil centrum Zlína" },
                    { 8, 2, "Významný objev v oblasti nanotechnologií byl publikován v prestižním vědeckém časopise Nature. Tým vedl profesor Jan Novák.", "/img/img2.jpg", "Výzkumný tým UTB publikoval v Nature" },
                    { 9, 8, "Více než 2000 potenciálních studentů navštívilo UTB během Dne otevřených dveří. Největší zájem byl o technické a kreativní obory.", "/img/img1.jpg", "Den otevřených dveří přilákal rekordní počet zájemců" },
                    { 10, 6, "V akademickém roce 2023/24 vyjede na zahraniční pobyt nejvíce studentů v historii UTB. Nejoblíbenější destinací je Španělsko.", "/img/img2.jpg", "Erasmus+ na UTB: Rekordní počet výjezdů" },
                    { 11, 7, "Tým studentů FAI získal první místo v prestižní mezinárodní soutěži robotiky v Tokiu. Jejich robot vynikal v oblasti autonomního rozhodování.", "/img/img1.jpg", "Úspěch studentů v mezinárodní soutěži robotiky" },
                    { 12, 5, "Moderní knihovna s kapacitou 500 míst nabízí studentům nejnovější technologie a příjemné prostředí pro studium.", "/img/img2.jpg", "Nová univerzitní knihovna otevřena" },
                    { 13, 3, "Studenti ateliéru Design oděvu prezentovali své kolekce na prestižní módní přehlídce. Zaujali originálním pojetím udržitelné módy.", "/img/img1.jpg", "Fakulta designu představila kolekci na Fashion Week" },
                    { 14, 8, "Spolupráce přinese studentům přístup k nejnovějším technologiím a možnost stáží v technologickém gigantu.", "/img/img2.jpg", "UTB podepsala strategické partnerství s Microsoft" },
                    { 15, 4, "Hokejisté UTB porazili tým UK Praha a postupují do finále univerzitní ligy. Finálový zápas se odehraje příští týden.", "/img/img1.jpg", "Univerzitní hokejový tým postupuje do finále" },
                    { 16, 1, "UTB rozšiřuje nabídku stipendijních programů. Nově nabízí podporu pro inovativní projekty a výzkumné aktivity studentů.", "/img/img2.jpg", "Nové stipendijní programy pro nadané studenty" }
                });

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagID",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 4,
                column: "TagID",
                value: 7);

            migrationBuilder.InsertData(
                table: "ArticleTag",
                columns: new[] { "Id", "ArticleID", "TagID" },
                values: new object[,]
                {
                    { 5, 3, 2 },
                    { 6, 3, 9 }
                });

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArticleId", "ImageAlt" },
                values: new object[] { 1, "UTB získala prestižní ocenění za výzkum" });

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArticleId", "ImageAlt" },
                values: new object[] { 2, "Inovativní projekty studentů designu" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Studium");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Věda a výzkum");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Kultura" },
                    { 4, "Sport" },
                    { 5, "Univerzitní život" },
                    { 6, "Mezinárodní" },
                    { 7, "Technologie" },
                    { 8, "Události" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Úspěch" },
                    { 4, "Studentský život" },
                    { 5, "Výzkum" },
                    { 6, "Spolupráce" },
                    { 7, "Akce" },
                    { 8, "Mezinárodní" },
                    { 9, "Technologie" },
                    { 10, "Vzdělávání" }
                });

            migrationBuilder.InsertData(
                table: "Carousel",
                columns: new[] { "Id", "ArticleId", "ImageAlt", "ImageSrc" },
                values: new object[] { 3, 3, "Nové technologické centrum na FAI", "/img/img1.jpg" });

            migrationBuilder.CreateIndex(
                name: "IX_Carousel_ArticleId",
                table: "Carousel",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carousel_Article_ArticleId",
                table: "Carousel",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carousel_Article_ArticleId",
                table: "Carousel");

            migrationBuilder.DropIndex(
                name: "IX_Carousel_ArticleId",
                table: "Carousel");

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tag",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Carousel");

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoryID", "Description", "Title" },
                values: new object[] { 1, "Popis prvního článku.", "První článek" });

            migrationBuilder.UpdateData(
                table: "Article",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoryID", "Description", "Title" },
                values: new object[] { 2, "Popis druhého článku.", "Druhý článek" });

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 1,
                column: "TagID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 2,
                column: "TagID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ArticleTag",
                keyColumn: "Id",
                keyValue: 4,
                column: "TagID",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageAlt",
                value: "První článek");

            migrationBuilder.UpdateData(
                table: "Carousel",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageAlt",
                value: "Druhý článek");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Technologie");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Zprávy");
        }
    }
}
