using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using UTB.Zpravodajstvi.Domain.Validations;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    [Table(nameof(Article))]
    public class Article : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Title { get; set; }
        [FirstLetterCapitalizedCZ]
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public int CategoryID { get; set; }
    }
}
