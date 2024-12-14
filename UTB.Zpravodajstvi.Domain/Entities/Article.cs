using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    public class Article : Entity<int>
    {
        [Required]
        [StringLength(70)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public required Category Category { get; set; }
        public required ICollection<ArticleTag> ArticleTags { get; set; }
        public int AuthorID { get; set; }
        public required IUser<int> Author { get; set; }
    }
}
