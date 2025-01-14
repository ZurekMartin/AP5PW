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
        public CarouselArticleViewModel()
        {
            Carousels = new List<Carousel>();
            Articles = new List<Article>();
            Categories = new List<Category>();
            Tags = new List<Tag>();
        }

        public IList<Carousel> Carousels { get; set; }
        public IList<Article> Articles { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Tag> Tags { get; set; }
    }
}
