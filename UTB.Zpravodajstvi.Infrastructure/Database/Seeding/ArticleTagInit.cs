using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class ArticleTagInit
    {
        public IList<ArticleTag> GetArticleTags()
        {
            return new List<ArticleTag>
            {
                new ArticleTag { Id = 1, ArticleID = 1, TagID = 2 }, 
                new ArticleTag { Id = 2, ArticleID = 1, TagID = 5 }, 
                new ArticleTag { Id = 3, ArticleID = 2, TagID = 1 }, 
                new ArticleTag { Id = 4, ArticleID = 2, TagID = 7 }, 
                new ArticleTag { Id = 5, ArticleID = 3, TagID = 2 }, 
                new ArticleTag { Id = 6, ArticleID = 3, TagID = 9 }, 
            };
        }
    }
}
