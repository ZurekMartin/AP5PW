using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselArticleViewModel GetHomeViewModel();
        IList<Carousel> GetCarousels();
        IList<Article> GetArticles();
        IList<Category> GetCategories();
        IList<Tag> GetTags();
    }
}
