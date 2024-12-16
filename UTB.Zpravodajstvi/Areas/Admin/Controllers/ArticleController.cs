using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;

namespace UTB.Zpravodajstvi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Writer))]
    public class ArticleController : Controller
    {
        IArticleAppService _articleAppService;
        public ArticleController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        // GET: /<controller>/
        public IActionResult Select()
        {
            IList<Article> articles = _articleAppService.Select();
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                _articleAppService.Create(article);
                return RedirectToAction(nameof(ArticleController.Select));
            }
            return View(article);
        }

        public IActionResult Delete(int id)
        {
            bool deleted = _articleAppService.Delete(id);
            if (deleted)
            {
                return RedirectToAction(nameof(ArticleController.Select));
            }
            else
                return NotFound();
        }
    }
}
