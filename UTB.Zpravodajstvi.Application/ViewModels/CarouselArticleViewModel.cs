using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Application.ViewModels
{
    public class CarouselArticleViewModel
    {
        public IList<Carousel>? Carousels { get; set; }
        public IList<Article>? Articles { get; set; }
    }
}
