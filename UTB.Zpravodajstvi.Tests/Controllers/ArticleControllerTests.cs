using Microsoft.AspNetCore.Mvc;
using Moq;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Areas.Admin.Controllers;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Tests.Database;
using Xunit;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Tests.Controllers
{
    public class ArticleControllerTests : IDisposable
    {
        private readonly ArticleController _controller;
        private readonly Mock<IArticleAppService> _mockArticleService;
        private readonly Mock<ILogger<ArticleController>> _mockLogger;
        private readonly ZpravodajstviDbContext _dbContext;

        public ArticleControllerTests()
        {
            _dbContext = TestDatabase.CreateDbContext();
            _mockArticleService = new Mock<IArticleAppService>();
            _mockLogger = new Mock<ILogger<ArticleController>>();
            _controller = new ArticleController(_mockArticleService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Select_ReturnsViewWithArticles()
        {
            // Arrange
            var articles = new List<Article>
            {
                new Article { Id = 1, Title = "Test Article 1" },
                new Article { Id = 2, Title = "Test Article 2" }
            };
            _mockArticleService.Setup(s => s.Select()).Returns(articles);

            // Act
            var result = _controller.Select();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IList<Article>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void Create_Post_ValidModel_RedirectsToSelect()
        {
            // Arrange
            var article = new Article { Id = 1, Title = "Test Article" };
            _mockArticleService.Setup(s => s.Create(It.IsAny<Article>())).Verifiable();

            // Act
            var result = _controller.Create(article);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(ArticleController.Select), redirectResult.ActionName);
            _mockArticleService.Verify(s => s.Create(It.IsAny<Article>()), Times.Once);
        }

        [Fact]
        public void Update_Get_ReturnsViewWithArticle()
        {
            // Arrange
            var article = new Article { Id = 1, Title = "Test Article" };
            _mockArticleService.Setup(s => s.GetById(1)).Returns(article);

            // Act
            var result = _controller.Update(1);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<Article>(viewResult.Model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public void Create_Get_ReturnsView()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Create_InvalidModel_ReturnsView()
        {
            // Arrange
            var article = new Article { Id = 0 };
            _controller.ModelState.AddModelError("Title", "Required");

            // Act
            var result = _controller.Create(article);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(article, viewResult.Model);
        }

        [Fact]
        public void Delete_ExistingArticle_RedirectsToSelect()
        {
            // Arrange
            _mockArticleService.Setup(s => s.Delete(1)).Returns(true);

            // Act
            var result = _controller.Delete(1);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(ArticleController.Select), redirectResult.ActionName);
        }

        [Fact]
        public void Delete_NonExistingArticle_ReturnsNotFound()
        {
            // Arrange
            _mockArticleService.Setup(s => s.Delete(999)).Returns(false);

            // Act
            var result = _controller.Delete(999);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
} 