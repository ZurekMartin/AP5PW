using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class HomeService : IHomeService
    {
        private readonly ZpravodajstviDbContext _zpravodajstviDbContext;

        public HomeService(ZpravodajstviDbContext zpravodajstviDbContext)
        {
            _zpravodajstviDbContext = zpravodajstviDbContext;
        }

        public CarouselArticleViewModel GetHomeViewModel()
        {
            return new CarouselArticleViewModel
            {
                Carousels = GetCarousels(),
                Articles = GetArticles(),
                Categories = GetCategories(),
                Tags = GetTags()
            };
        }

        public IList<Carousel> GetCarousels()
        {
            return _zpravodajstviDbContext.Carousels.ToList();
        }

        public IList<Article> GetArticles()
        {
            return _zpravodajstviDbContext.Articles
                .Include(a => a.Category)
                .Include(a => a.ArticleTags)
                    .ThenInclude(at => at.Tag)
                .ToList();
        }

        public IList<Category> GetCategories()
        {
            return _zpravodajstviDbContext.Categories.ToList();
        }

        public IList<Tag> GetTags()
        {
            return _zpravodajstviDbContext.Tags.ToList();
        }
    }
}