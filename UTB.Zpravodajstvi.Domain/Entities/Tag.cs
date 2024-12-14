using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    [Table(nameof(Tag))]
    public class Tag : Entity<int>
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }
    }
}
