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
            IList<Article> articles = new List<Article>();

            articles.Add(new Article
            {
                Id = 1,
                Title = "První článek",
                Description = "Popis prvního článku.",
                ImageSrc = "/img/img1.jpg",
                CategoryID = 1
            });
            articles.Add(new Article
            {
                Id = 2,
                Title = "Druhý článek",
                Description = "Popis druhého článku.",
                ImageSrc = "/img/img2.jpg",
                CategoryID = 2
            });

            return articles;
        }
    }
}
