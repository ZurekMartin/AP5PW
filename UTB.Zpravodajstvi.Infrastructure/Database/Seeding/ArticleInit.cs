using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class ArticleInit
    {
        public IList<Article> GetArticles()
{
    return new List<Article>
    {
        new Article
        {
            Id = 1,
            Title = "UTB získala prestižní ocenění za výzkum v oblasti polymerů",
            Description = "Výzkumný tým Fakulty technologické UTB dosáhl významného úspěchu v oblasti vývoje biodegradabilních polymerů. Projekt získal mezinárodní uznání na konferenci v Berlíně.",
            ImageSrc = "/img/articles/img1.jpg",
            CategoryID = 2 
        },
        new Article
        {
            Id = 2,
            Title = "Studenti designu představili inovativní projekty na Design Week",
            Description = "Fakulta multimediálních komunikací prezentovala práce studentů na mezinárodním Design Week. Projekty se zaměřily na udržitelný design a sociální inovace.",
            ImageSrc = "/img/articles/img2.jpg",
            CategoryID = 3 
        },
        new Article
        {
            Id = 3,
            Title = "Nové technologické centrum otevřeno na FAI",
            Description = "Fakulta aplikované informatiky otevřela moderní centrum pro výzkum umělé inteligence a kybernetické bezpečnosti. Centrum nabídne studentům špičkové vybavení.",
            ImageSrc = "/img/articles/img3.jpg",
            CategoryID = 7 
        },
        new Article
        {
            Id = 4,
            Title = "Mezinárodní konference o udržitelném rozvoji na UTB",
            Description = "UTB hostila významnou mezinárodní konferenci zaměřenou na udržitelný rozvoj a zelené technologie. Účastnili se odborníci z celého světa.",
            ImageSrc = "/img/articles/img4.jpg",
            CategoryID = 6
        },
        new Article
        {
            Id = 5,
            Title = "Sportovci UTB zazářili na Univerzitních hrách",
            Description = "Reprezentanti UTB získali několik medailí na Českých akademických hrách. Vynikajících výsledků dosáhli zejména v atletice a plavání.",
            ImageSrc = "/img/articles/img5.jpg",
            CategoryID = 4
            },
        new Article
        {
            Id = 6,
            Title = "Nový studijní program: Digitální transformace",
            Description = "Fakulta managementu a ekonomiky představuje nový studijní program zaměřený na digitální transformaci podniků a průmysl 4.0.",
            ImageSrc = "/img/articles/img6.jpg",
            CategoryID = 1 
        },
        new Article
        {
            Id = 7,
            Title = "Studentský festival oživil centrum Zlína",
            Description = "Tradiční studentský festival přinesl do ulic Zlína kulturu, umění a zábavu. Akce přilákala tisíce návštěvníků.",
            ImageSrc = "/img/articles/img7.jpg",
            CategoryID = 5 
        },
        new Article
        {
            Id = 8,
            Title = "Výzkumný tým UTB publikoval v Nature",
            Description = "Významný objev v oblasti nanotechnologií byl publikován v prestižním vědeckém časopise Nature. Tým vedl profesor Jan Novák.",
            ImageSrc = "/img/articles/img8.jpg",
            CategoryID = 2
        },
        new Article
        {
            Id = 9,
            Title = "Den otevřených dveří přilákal rekordní počet zájemců",
            Description = "Více než 2000 potenciálních studentů navštívilo UTB během Dne otevřených dveří. Největší zájem byl o technické a kreativní obory.",
            ImageSrc = "/img/articles/img9.jpg",
            CategoryID = 8
        },
        new Article
        {
            Id = 10,
            Title = "Erasmus+ na UTB: Rekordní počet výjezdů",
            Description = "V akademickém roce 2023/24 vyjede na zahraniční pobyt nejvíce studentů v historii UTB. Nejoblíbenější destinací je Španělsko.",
            ImageSrc = "/img/articles/img10.jpg",
            CategoryID = 6 
        },
        new Article
        {
            Id = 11,
            Title = "Úspěch studentů v mezinárodní soutěži robotiky",
            Description = "Tým studentů FAI získal první místo v prestižní mezinárodní soutěži robotiky v Tokiu. Jejich robot vynikal v oblasti autonomního rozhodování.",
            ImageSrc = "/img/articles/img11.jpg",
            CategoryID = 7 
        },
        new Article
        {
            Id = 12,
            Title = "Nová univerzitní knihovna otevřena",
            Description = "Moderní knihovna s kapacitou 500 míst nabízí studentům nejnovější technologie a příjemné prostředí pro studium.",
            ImageSrc = "/img/articles/img12.jpg",
            CategoryID = 5 
        },
        new Article
        {
            Id = 13,
            Title = "Fakulta designu představila kolekci na Fashion Week",
            Description = "Studenti ateliéru Design oděvu prezentovali své kolekce na prestižní módní přehlídce. Zaujali originálním pojetím udržitelné módy.",
            ImageSrc = "/img/articles/img13.jpg",
            CategoryID = 3 
        },
        new Article
        {
            Id = 14,
            Title = "UTB podepsala strategické partnerství s Microsoft",
            Description = "Spolupráce přinese studentům přístup k nejnovějším technologiím a možnost stáží v technologickém gigantu.",
            ImageSrc = "/img/articles/img14.jpg",
            CategoryID = 8 
        },
        new Article
        {
            Id = 15,
            Title = "Univerzitní hokejový tým postupuje do finále",
            Description = "Hokejisté UTB porazili tým UK Praha a postupují do finále univerzitní ligy. Finálový zápas se odehraje příští týden.",
            ImageSrc = "/img/articles/img15.jpg",
            CategoryID = 4 
        },
        new Article
        {
            Id = 16,
            Title = "Nové stipendijní programy pro nadané studenty",
            Description = "UTB rozšiřuje nabídku stipendijních programů. Nově nabízí podporu pro inovativní projekty a výzkumné aktivity studentů.",
            ImageSrc = "/img/articles/img16.jpg",
            CategoryID = 1
        }
    };
}
    }
}
