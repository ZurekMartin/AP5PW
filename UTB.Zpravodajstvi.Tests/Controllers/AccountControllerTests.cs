using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Areas.Security.Controllers;
using UTB.Zpravodajstvi.Infrastructure.Database;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;
using UTB.Zpravodajstvi.Tests.Database;
using Xunit;

namespace UTB.Zpravodajstvi.Tests.Controllers
{
    public class AccountControllerTests : IDisposable
    {
        private readonly AccountController _controller;
        private readonly Mock<IAccountService> _mockAccountService;
        private readonly Mock<ILogger<AccountController>> _mockLogger;
        private readonly ZpravodajstviDbContext _dbContext;

        public AccountControllerTests()
        {
            _dbContext = TestDatabase.CreateDbContext();
            _mockAccountService = new Mock<IAccountService>();
            _mockLogger = new Mock<ILogger<AccountController>>();
            _controller = new AccountController(_mockAccountService.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task Register_ValidUser_ReturnsRedirectToHome()
        {
            // Arrange
            var registerVM = new RegisterViewModel
            {
                Username = "testuser",
                Email = "test@test.com",
                Password = "password123",
                FirstName = "Test",
                LastName = "User"
            };

            _mockAccountService
                .Setup(x => x.Register(It.IsAny<RegisterViewModel>(), Roles.Reader))
                .ReturnsAsync((string[])null);

            _mockAccountService
                .Setup(x => x.Login(It.IsAny<LoginViewModel>()))
                .ReturnsAsync(true);

            // Act
            var result = await _controller.Register(registerVM);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Register_InvalidUser_ReturnsViewWithModel()
        {
            // Arrange
            var registerVM = new RegisterViewModel
            {
                Username = "testuser",
                Email = "invalid-email",
                Password = "pwd",
                FirstName = "Test",
                LastName = "User"
            };

            _controller.ModelState.AddModelError("Email", "Invalid email format");

            // Act
            var result = await _controller.Register(registerVM);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(registerVM, viewResult.Model);
        }

        [Fact]
        public async Task Register_RegistrationFailed_ReturnsViewWithErrors()
        {
            // Arrange
            var registerVM = new RegisterViewModel
            {
                Username = "testuser",
                Email = "test@test.com",
                Password = "password123",
                FirstName = "Test",
                LastName = "User"
            };

            string[] errors = new[] { "Username already exists" };
            _mockAccountService
                .Setup(x => x.Register(It.IsAny<RegisterViewModel>(), Roles.Reader))
                .ReturnsAsync(errors);

            // Act
            var result = await _controller.Register(registerVM);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(registerVM, viewResult.Model);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
} 