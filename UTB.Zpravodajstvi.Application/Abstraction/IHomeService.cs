using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Application.ViewModels;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IHomeService
    {
        CarouselArticleViewModel GetIndexViewModel();
    }
}
