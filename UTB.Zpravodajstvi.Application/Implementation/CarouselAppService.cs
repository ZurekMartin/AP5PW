using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Domain.Entities;
using UTB.Zpravodajstvi.Infrastructure.Database;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class CarouselAppService : ICarouselAppService
    {
        ZpravodajstviDbContext _zpravodajstviDbContext;
        public CarouselAppService(ZpravodajstviDbContext zpravodajstviDbContext)
        {
            _zpravodajstviDbContext = zpravodajstviDbContext;
        }
        public IList<Carousel> Select()
        {
            return _zpravodajstviDbContext.Carousels.ToList();
        }
    }
}
