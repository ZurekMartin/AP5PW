using Microsoft.AspNetCore.Mvc;
using Moq;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Areas.Admin.Controllers;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using UTB.Zpravodajstvi.Tests.Database;
using Xunit;

namespace UTB.Zpravodajstvi.Tests.Controllers
{
    public class UserControllerTests : IDisposable
    {
        private readonly UserController _controller;
        private readonly Mock<IUserAppService> _mockUserService;
        private readonly ZpravodajstviDbContext _dbContext;

        public UserControllerTests()
        {
            _dbContext = TestDatabase.CreateDbContext();
            _mockUserService = new Mock<IUserAppService>();
            _controller = new UserController(_mockUserService.Object);
        }

        [Fact]
        public void Select_ReturnsViewWithUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, UserName = "user1" },
                new User { Id = 2, UserName = "user2" }
            };
            _mockUserService.Setup(s => s.Select()).Returns(users);

            // Act
            var result = _controller.Select();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IList<User>>(viewResult.Model);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task Update_ValidUser_RedirectsToSelect()
        {
            // Arrange
            var user = new User { Id = 1, UserName = "testuser" };
            _mockUserService.Setup(s => s.Update(It.IsAny<User>())).ReturnsAsync(true);

            // Act
            var result = await _controller.Update(user);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(UserController.Select), redirectResult.ActionName);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
} 