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
    public class HomeControllerTests : IDisposable
    {
        private readonly HomeController _controller;
        private readonly Mock<IHomeService> _mockHomeService;
        private readonly Mock<ILogger<HomeController>> _mockLogger;
        private readonly ZpravodajstviDbContext _dbContext;

        public HomeControllerTests()
        {
            _dbContext = TestDatabase.CreateDbContext();
            _mockHomeService = new Mock<IHomeService>();
            _mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_mockHomeService.Object, _mockLogger.Object);
        }

        [Fact]
        public void Index_ReturnsViewWithCarouselArticleViewModel()
        {
            // Arrange
            var viewModel = new CarouselArticleViewModel
            {
                Articles = new List<Article> { new Article { Id = 1, Title = "Test" } },
                Categories = new List<Category> { new Category { Id = 1, Name = "Test" } },
                Tags = new List<Tag> { new Tag { Id = 1, Name = "Test" } }
            };
            _mockHomeService.Setup(s => s.GetHomeViewModel()).Returns(viewModel);

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
        public void About_ReturnsViewResult()
        {
            // Act
            var result = _controller.About();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Uses default view name
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Act
            var result = _controller.Privacy();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName); // Uses default view name
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}