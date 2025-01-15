using Microsoft.AspNetCore.Mvc;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;

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
            var viewModel = new CarouselArticleViewModel
            {
                Articles = _articleAppService.Select(),
                Categories = _articleAppService.GetAllCategories(),
                Tags = _articleAppService.GetAllTags()
            };

            return View(viewModel);
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