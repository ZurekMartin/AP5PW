using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class CarouselInit
    {
        public IList<Carousel> GetCarousels()
        {
            IList<Carousel> carousels = new List<Carousel>();

            carousels.Add(new Carousel()
            {
                Id = 1,
                ImageSrc = "/img/img1.jpg",
                ImageAlt = "První článek"
            });
            carousels.Add(new Carousel()
            {
                Id = 2,
                ImageSrc = "/img/img2.jpg",
                ImageAlt = "Druhý článek"
            });

            return carousels;
        }
    }
}