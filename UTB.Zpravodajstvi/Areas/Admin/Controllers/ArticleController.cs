using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = nameof(Roles.Admin) + ", " + nameof(Roles.Writer))]
    public class ArticleController : Controller
    {
        private readonly IArticleAppService _articleAppService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleAppService articleAppService, ILogger<ArticleController> logger)
        {
            _articleAppService = articleAppService;
            _logger = logger;
        }

        public IActionResult Select()
        {
            _logger.LogInformation("Admin: Zobrazení seznamu článků");
            IList<Article> articles = _articleAppService.Select();
            _logger.LogInformation("Admin: Načteno {Count} článků", articles.Count);
            return View(articles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            _logger.LogInformation("Admin: Zobrazení formuláře pro vytvoření článku");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Admin: Pokus o vytvoření článku: {Title}", article.Title);
                _articleAppService.Create(article);
                _logger.LogInformation("Admin: Článek byl úspěšně vytvořen: {Title} (ID: {ArticleId})", 
                    article.Title, article.Id);
                return RedirectToAction(nameof(Select));
            }
            _logger.LogWarning("Admin: Neplatný model při vytváření článku");
            return View(article);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            _logger.LogInformation("Admin: Požadavek na úpravu článku ID: {ArticleId}", id);
            Article article = _articleAppService.GetById(id);
            if (article == null)
            {
                _logger.LogWarning("Admin: Článek pro úpravu nebyl nalezen, ID: {ArticleId}", id);
                return NotFound();
            }
            return View(article);
        }

        [HttpPost]
        public IActionResult Update(Article article)
        {
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Admin: Pokus o aktualizaci článku ID: {ArticleId}", article.Id);
                bool updated = _articleAppService.Update(article);
                if (updated)
                {
                    _logger.LogInformation("Admin: Článek byl úspěšně aktualizován: {Title} (ID: {ArticleId})", 
                        article.Title, article.Id);
                    return RedirectToAction(nameof(Select));
                }
                _logger.LogError("Admin: Chyba při aktualizaci článku ID: {ArticleId}", article.Id);
                ModelState.AddModelError("", "Failed to update the article.");
            }
            _logger.LogWarning("Admin: Neplatný model při aktualizaci článku ID: {ArticleId}", article.Id);
            return View(article);
        }

        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Admin: Pokus o smazání článku ID: {ArticleId}", id);
            bool deleted = _articleAppService.Delete(id);
            if (deleted)
            {
                _logger.LogInformation("Admin: Článek byl úspěšně smazán, ID: {ArticleId}", id);
                return RedirectToAction(nameof(Select));
            }
            _logger.LogWarning("Admin: Článek pro smazání nebyl nalezen, ID: {ArticleId}", id);
            return NotFound();
        }
    }
}
