using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    [Table(nameof(Carousel))]
    public class Carousel : Entity<int>
    {
        public required string ImageSrc { get; set; }
        public required string ImageAlt { get; set; }
        public required int ArticleId { get; set; }
        
        [ForeignKey(nameof(ArticleId))]
        public virtual Article? Article { get; set; }
    }
}
