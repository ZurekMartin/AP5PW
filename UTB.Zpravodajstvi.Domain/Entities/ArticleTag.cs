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
        public int ArticleID { get; set; }
        public int TagID { get; set; }
        public required Article Article { get; set; }
        public required Tag Tag { get; set; }
    }
}
