using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;

namespace UTB.Zpravodajstvi.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleAppService _articleAppService;

        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        public IActionResult Index()
        {
            var articles = _articleAppService.Select();
            return View(articles);
        }

        public IActionResult Detail(int id)
        {
            var article = _articleAppService.GetById(id);
            if (article == null)
                return NotFound();
            return View(article);
        }
    }
} 