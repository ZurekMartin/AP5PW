using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;

namespace UTB.Zpravodajstvi.Domain.Entities
{
    public class Entity<TKey> : IEntity<TKey>
    {
        public required TKey Id { get; set; }
    }
}
