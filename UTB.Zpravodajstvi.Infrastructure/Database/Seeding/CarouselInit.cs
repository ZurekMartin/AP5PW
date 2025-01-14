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
            return new List<Carousel>
            {
                new Carousel
                {
                    Id = 1,
                    ImageSrc = "/img/img1.jpg",
                    ImageAlt = "UTB získala prestižní ocenění za výzkum",
                    ArticleId = 1
                },
                new Carousel
                {
                    Id = 2,
                    ImageSrc = "/img/img2.jpg",
                    ImageAlt = "Inovativní projekty studentů designu",
                    ArticleId = 2
                },
                new Carousel
                {
                    Id = 3,
                    ImageSrc = "/img/img1.jpg",
                    ImageAlt = "Nové technologické centrum na FAI",
                    ArticleId = 3
                }
            };
        }
    }
}