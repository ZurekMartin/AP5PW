using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Application.Abstraction;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class ArticleAppService : IArticleAppService
    {
        ZpravodajstviDbContext _zpravodajstviDbContext;
        public ArticleAppService(ZpravodajstviDbContext zpravodajstviDbContext)
        {
            _zpravodajstviDbContext = zpravodajstviDbContext;
        }
        public IList<Article> Select()
        {
            return _zpravodajstviDbContext.Articles.ToList();
        }
        public void Create(Article article)
        {
            _zpravodajstviDbContext.Articles.Add(article);
            _zpravodajstviDbContext.SaveChanges();
        }
        public bool Delete(int id)
        {
            bool deleted = false;

            Article? article = _zpravodajstviDbContext.Articles.FirstOrDefault(art => art.Id == id);

            if (article != null)
            {
                _zpravodajstviDbContext.Articles.Remove(article);
                _zpravodajstviDbContext.SaveChanges();
                deleted = true;
            }
            return deleted;
        }
    }
}
