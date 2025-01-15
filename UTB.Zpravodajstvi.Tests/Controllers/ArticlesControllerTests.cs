using Microsoft.AspNetCore.Mvc;
using Moq;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Controllers;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Tests.Database;
using Xunit;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Tests.Controllers
{
    public class ArticlesControllerTests : IDisposable
    {
        private readonly ArticlesController _controller;
        private readonly Mock<IArticleAppService> _mockArticleService;
        private readonly Mock<ILogger<ArticlesController>> _mockLogger;
        private readonly ZpravodajstviDbContext _dbContext;

        public ArticlesControllerTests()
        {
            _dbContext = TestDatabase.CreateDbContext();
            _mockArticleService = new Mock<IArticleAppService>();
            _mockLogger = new Mock<ILogger<ArticlesController>>();
            _controller = new ArticlesController(_mockArticleService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Index_ReturnsViewWithCarouselArticleViewModel()
        {
            // Arrange
            var articles = new List<Article> { new Article { Id = 1, Title = "Test" } };
            var categories = new List<Category> { new Category { Id = 1, Name = "Test" } };
            var tags = new List<Tag> { new Tag { Id = 1, Name = "Test" } };

            _mockArticleService.Setup(s => s.Select()).Returns(articles);
            _mockArticleService.Setup(s => s.GetAllCategories()).Returns(categories);
            _mockArticleService.Setup(s => s.GetAllTags()).Returns(tags);

            // Act
            var result = _controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<CarouselArticleViewModel>(viewResult.Model);
            Assert.NotNull(model.Articles);
            Assert.NotNull(model.Categories);
            Assert.NotNull(model.Tags);
        }

        [Fact]
        public void Detail_ExistingArticle_ReturnsViewWithArticle()
        {
            // Arrange
            var article = new Article { Id = 1, Title = "Test Article" };
            _mockArticleService.Setup(s => s.GetById(1)).Returns(article);

            // Act
            var result = _controller.Detail(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Article>(viewResult.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Detail_NonExistingArticle_ReturnsNotFound()
        {
            // Arrange
            _mockArticleService.Setup(s => s.GetById(999)).Returns((Article)null);

            // Act
            var result = _controller.Detail(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
} 