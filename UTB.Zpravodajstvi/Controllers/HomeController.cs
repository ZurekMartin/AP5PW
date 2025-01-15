using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UTB.Zpravodajstvi.Models;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using Microsoft.Extensions.Logging;

namespace UTB.Zpravodajstvi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHomeService homeService, ILogger<HomeController> logger)
        {
            _homeService = homeService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Zobrazení domovské stránky");
            var viewModel = _homeService.GetHomeViewModel();
            _logger.LogInformation("Načteno {Count} článků pro domovskou stránku", 
                viewModel.Articles?.Count() ?? 0);
            return View(viewModel);
        }

        public IActionResult About()
        {
            _logger.LogInformation("Zobrazení stránky O nás");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Zobrazení stránky Ochrana soukromí");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var requestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            _logger.LogError("Došlo k chybě. RequestId: {RequestId}", requestId);
            return View(new ErrorViewModel { RequestId = requestId });
        }
    }
}
