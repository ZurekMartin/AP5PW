using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface ICarouselAppService
    {
        IList<Carousel> Select();
    }
}
