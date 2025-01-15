using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleAppService _articleAppService;
        private readonly ILogger<ArticlesController> _logger;

        public ArticlesController(IArticleAppService articleAppService, ILogger<ArticlesController> logger)
        {
            _articleAppService = articleAppService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Zobrazení seznamu článků");
            var viewModel = new CarouselArticleViewModel
            {
                Articles = _articleAppService.Select(),
                Categories = _articleAppService.GetAllCategories(),
                Tags = _articleAppService.GetAllTags()
            };
            _logger.LogInformation("Načteno {Count} článků", viewModel.Articles.Count());
            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            _logger.LogInformation("Požadavek na detail článku ID: {ArticleId}", id);
            var article = _articleAppService.GetById(id);
            if (article == null)
            {
                _logger.LogWarning("Článek s ID: {ArticleId} nebyl nalezen", id);
                return NotFound();
            }
            _logger.LogInformation("Zobrazen článek: {ArticleTitle} (ID: {ArticleId})", article.Title, id);
            return View(article);
        }
    }
} 