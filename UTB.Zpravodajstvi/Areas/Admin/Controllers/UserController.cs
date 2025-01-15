using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Infrastructure.Identity;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;

namespace UTB.Zpravodajstvi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin))]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public IActionResult Select()
        {
            var users = _userAppService.Select();
            return View(users);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _userAppService.GetById(id);
            if (user == null)
                return NotFound();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Update(User user)
        {
            if (ModelState.IsValid)
            {
                bool updated = await _userAppService.Update(user);
                if (updated)
                    return RedirectToAction(nameof(Select));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _userAppService.Delete(id);
            if (deleted)
                return RedirectToAction(nameof(Select));
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeRole(int userId, string newRole)
        {
            bool changed = await _userAppService.ChangeRole(userId, newRole);
            return Json(new { success = changed });
        }
    }
} 