using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class HomeService : IHomeService
    {
        IArticleAppService _articleAppService;
        ICarouselAppService _carouselAppService;
        public HomeService(IArticleAppService articleAppService,
                           ICarouselAppService carouselAppService)
        {
            _articleAppService = articleAppService;
            _carouselAppService = carouselAppService;
        }
        public CarouselArticleViewModel GetIndexViewModel()
        {
            CarouselArticleViewModel viewModel = new CarouselArticleViewModel();
            viewModel.Articles = _articleAppService.Select();
            viewModel.Carousels = _carouselAppService.Select();
            return viewModel;
        }
    }
}