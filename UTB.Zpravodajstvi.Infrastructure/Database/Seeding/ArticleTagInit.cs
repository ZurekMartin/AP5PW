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
                new ArticleTag { Id = 7, ArticleID = 4, TagID = 3 }, 
                new ArticleTag { Id = 8, ArticleID = 4, TagID = 6 }, 
                new ArticleTag { Id = 9, ArticleID = 5, TagID = 4 }, 
                new ArticleTag { Id = 10, ArticleID = 5, TagID = 8 }, 
                new ArticleTag { Id = 11, ArticleID = 6, TagID = 1 }, 
                new ArticleTag { Id = 12, ArticleID = 6, TagID = 5 }, 
                new ArticleTag { Id = 13, ArticleID = 7, TagID = 2 }, 
                new ArticleTag { Id = 14, ArticleID = 7, TagID = 6 }, 
                new ArticleTag { Id = 15, ArticleID = 8, TagID = 3 }, 
                new ArticleTag { Id = 16, ArticleID = 8, TagID = 9 }, 
                new ArticleTag { Id = 17, ArticleID = 9, TagID = 4 }, 
                new ArticleTag { Id = 18, ArticleID = 9, TagID = 8 }, 
                new ArticleTag { Id = 19, ArticleID = 10, TagID = 1 }, 
                new ArticleTag { Id = 20, ArticleID = 10, TagID = 5 }, 
                new ArticleTag { Id = 21, ArticleID = 11, TagID = 2 }, 
                new ArticleTag { Id = 22, ArticleID = 11, TagID = 7 }, 
                new ArticleTag { Id = 23, ArticleID = 12, TagID = 3 }, 
                new ArticleTag { Id = 24, ArticleID = 12, TagID = 6 },
                new ArticleTag { Id = 25, ArticleID = 13, TagID = 1 }, 
                new ArticleTag { Id = 26, ArticleID = 13, TagID = 5 }, 
                new ArticleTag { Id = 27, ArticleID = 14, TagID = 2 },
                new ArticleTag { Id = 28, ArticleID = 14, TagID = 8 }, 
                new ArticleTag { Id = 29, ArticleID = 15, TagID = 4 }, 
                new ArticleTag { Id = 30, ArticleID = 15, TagID = 6 }, 
                new ArticleTag { Id = 31, ArticleID = 16, TagID = 1 }, 
                new ArticleTag { Id = 32, ArticleID = 16, TagID = 5 } 
            };
        }
    }
}
