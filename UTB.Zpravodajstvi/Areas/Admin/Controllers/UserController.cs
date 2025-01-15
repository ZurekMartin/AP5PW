using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserAppService userAppService, ILogger<UserController> logger)
        {
            _userAppService = userAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Admin: Zobrazení seznamu uživatelů");
            var users = _userAppService.Select();
            _logger.LogInformation("Admin: Načteno {Count} uživatelů", users.Count);
            return View(users);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            _logger.LogInformation("Admin: Požadavek na úpravu uživatele ID: {UserId}", id);
            var user = _userAppService.GetById(id);
            if (user == null)
            {
                _logger.LogWarning("Admin: Uživatel pro úpravu nebyl nalezen, ID: {UserId}", id);
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Admin: Pokus o aktualizaci uživatele ID: {UserId}", user.Id);
                bool updated = await _userAppService.Update(user);
                if (updated)
                {
                    _logger.LogInformation("Admin: Uživatel byl úspěšně aktualizován: {Username} (ID: {UserId})", 
                        user.UserName, user.Id);
                    return RedirectToAction(nameof(Select));
                }
                _logger.LogError("Admin: Chyba při aktualizaci uživatele ID: {UserId}", user.Id);
            }
            _logger.LogWarning("Admin: Neplatný model při aktualizaci uživatele ID: {UserId}", user.Id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(int userId, string newRole)
        {
            _logger.LogInformation("Admin: Pokus o změnu role uživatele ID: {UserId} na {NewRole}", userId, newRole);
            bool changed = await _userAppService.ChangeRole(userId, newRole);
            if (changed)
                _logger.LogInformation("Admin: Role uživatele ID: {UserId} byla změněna na {NewRole}", userId, newRole);
            else
                _logger.LogWarning("Admin: Změna role selhala pro uživatele ID: {UserId}", userId);
            return Json(new { success = changed });
        }

        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Admin: Pokus o smazání uživatele ID: {UserId}", id);
            bool deleted = await _userAppService.Delete(id);
            if (deleted)
            {
                _logger.LogInformation("Admin: Uživatel byl úspěšně smazán, ID: {UserId}", id);
                return RedirectToAction(nameof(Select));
            }
            _logger.LogWarning("Admin: Uživatel pro smazání nebyl nalezen, ID: {UserId}", id);
            return NotFound();
        }
    }
} 