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
            IList<ArticleTag> articleTags = new List<ArticleTag>();

            articleTags.Add(new ArticleTag
            {
                Id = 1,
                ArticleID = 1,
                TagID = 1,
            });
            articleTags.Add(new ArticleTag
            {
                Id = 2,
                ArticleID = 1,
                TagID = 2,
            });
            articleTags.Add(new ArticleTag
            {
                Id = 3,
                ArticleID = 2,
                TagID= 1,
            });
            articleTags.Add(new ArticleTag
            {
                Id = 4,
                ArticleID = 2,
                TagID = 2,
            });

            return articleTags;
        }
    }
}
