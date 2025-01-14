using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTB.Zpravodajstvi.Models;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;

namespace UTB.Zpravodajstvi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IHomeService _homeService;
        ICarouselAppService _carouselAppService;
        IArticleAppService _articleAppService;

        public HomeController(ILogger<HomeController> logger,
                                  IHomeService homeService,
                                  ICarouselAppService carouselAppService,
                                  IArticleAppService articleAppService)
        {
            _logger = logger;
            _homeService = homeService;
            _carouselAppService = carouselAppService;
            _articleAppService = articleAppService;
        }

        public IActionResult Index()
        {
            CarouselArticleViewModel viewModel = new CarouselArticleViewModel()
            {
                Carousels = _carouselAppService.Select(),
                Articles = _articleAppService.Select().Take(6).ToList()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
