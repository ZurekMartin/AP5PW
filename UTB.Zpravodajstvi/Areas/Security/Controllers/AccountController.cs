using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Controllers;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Areas.Security.Controllers
{
    [Area("Security")]
    public class AccountController : Controller
    {
        IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService security, ILogger<AccountController> logger)
        {
            _accountService = security;
            _logger = logger;
        }

        public IActionResult Register()
        {
            _logger.LogInformation("Zobrazení registračního formuláře");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Pokus o registraci uživatele: {Username}", registerVM.Username);
                string[] errors = await _accountService.Register(registerVM, Roles.Reader);
                if (errors == null)
                {
                    LoginViewModel loginVM = new LoginViewModel()
                    {
                        Username = registerVM.Username,
                        Password = registerVM.Password
                    };
                    bool isLogged = await _accountService.Login(loginVM);
                    if (isLogged)
                    {
                        _logger.LogInformation("Uživatel {Username} byl úspěšně zaregistrován a přihlášen", registerVM.Username);
                        return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
                    }
                    else
                    {
                        _logger.LogWarning("Uživatel {Username} byl zaregistrován, ale přihlášení selhalo", registerVM.Username);
                        return RedirectToAction(nameof(Login));
                    }
                }
                else
                {
                    _logger.LogError("Chyba při registraci uživatele {Username}: {Errors}", 
                        registerVM.Username, 
                        string.Join(", ", errors));
                }
            }
            return View(registerVM);
        }

        public IActionResult Login()
        {
            _logger.LogInformation("Zobrazení přihlašovacího formuláře");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Pokus o přihlášení uživatele: {Username}", loginVM.Username);
                bool isLogged = await _accountService.Login(loginVM);
                if (isLogged)
                {
                    _logger.LogInformation("Uživatel {Username} byl úspěšně přihlášen", loginVM.Username);
                    return RedirectToAction(nameof(HomeController.Index), nameof(HomeController).Replace(nameof(Controller), String.Empty), new { area = String.Empty });
                }
                _logger.LogWarning("Neúspěšný pokus o přihlášení uživatele {Username}", loginVM.Username);
                loginVM.LoginFailed = true;
            }
            return View(loginVM);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            var username = User.Identity?.Name;
            _logger.LogInformation("Odhlášení uživatele: {Username}", username);
            await _accountService.Logout();
            return RedirectToAction(nameof(Login));
        }
    }
}