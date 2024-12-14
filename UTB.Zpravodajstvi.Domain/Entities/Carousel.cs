using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    public class Carousel : Entity<int>
    {
        public required string ImageSrc { get; set; }
        public required string ImageAlt { get; set; }
    }
}
