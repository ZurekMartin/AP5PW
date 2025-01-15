using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    [Table(nameof(ArticleTag))]
    public class ArticleTag : Entity<int>
    {
        [ForeignKey(nameof(ArticleID))]
        public int ArticleID { get; set; }
        public Article? Article { get; set; }

        [ForeignKey(nameof(TagID))]
        public int TagID { get; set; }
        public Tag? Tag { get; set; }
    }
}
