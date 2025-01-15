using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Application.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class ArticleAppService : IArticleAppService
    {
        ZpravodajstviDbContext _zpravodajstviDbContext;
        IFileUploadService _fileUploadService;
        public ArticleAppService(ZpravodajstviDbContext zpravodajstviDbContext, IFileUploadService fileUploadService)
        {
            _zpravodajstviDbContext = zpravodajstviDbContext;
            _fileUploadService = fileUploadService;
        }
        public IList<Article> Select()
        {
            return _zpravodajstviDbContext.Articles
                .Include(a => a.Category)
                .Include(a => a.ArticleTags)
                    .ThenInclude(at => at.Tag)
                .ToList();
        }
        public Article? GetById(int id)
        {
            return _zpravodajstviDbContext.Articles
                .Include(a => a.Category)
                .Include(a => a.ArticleTags)
                    .ThenInclude(at => at.Tag)
                .FirstOrDefault(a => a.Id == id);
        }
        public void Create(Article article)
        {
            if (article.Image != null)
            {
                string imageSrc = _fileUploadService.FileUpload(article.Image, Path.Combine("img", "Articles"));
                article.ImageSrc = imageSrc;
            }

            _zpravodajstviDbContext.Articles.Add(article);
            _zpravodajstviDbContext.SaveChanges();
        }
        public bool Update(Article article)
        {
            var existingArticle = _zpravodajstviDbContext.Articles.FirstOrDefault(a => a.Id == article.Id);

            if (existingArticle != null)
            {
                existingArticle.Title = article.Title;
                existingArticle.Description = article.Description;
                existingArticle.CategoryID = article.CategoryID;

                if (article.Image != null)
                {
                    string imageSrc = _fileUploadService.FileUpload(article.Image, Path.Combine("img", "Articles"));
                    existingArticle.ImageSrc = imageSrc;
                }

                _zpravodajstviDbContext.SaveChanges();
                return true;
            }
            return false;
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
        public IList<Category> GetAllCategories()
        {
            return _zpravodajstviDbContext.Categories.ToList();
        }
        public IList<Tag> GetAllTags()
        {
            return _zpravodajstviDbContext.Tags.ToList();
        }
    }
}
