using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    [Table(nameof(Article))]
    public class Article : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
