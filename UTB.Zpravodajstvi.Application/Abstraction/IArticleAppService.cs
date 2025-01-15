using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IArticleAppService
    {
        IList<Article> Select();
        Article GetById(int id);
        void Create(Article article);
        bool Update(Article article);
        bool Delete(int id);
        IList<Category> GetAllCategories();
        IList<Tag> GetAllTags();
    }
}
