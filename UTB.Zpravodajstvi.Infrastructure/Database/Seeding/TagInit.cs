using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class TagInit
    {
        public IList<Tag> GetTags()
        {
            return new List<Tag>
            {
                new Tag { Id = 1, Name = "Zajímavé" },
                new Tag { Id = 2, Name = "Inovace" },
                new Tag { Id = 3, Name = "Úspěch" },
                new Tag { Id = 4, Name = "Studentský život" },
                new Tag { Id = 5, Name = "Výzkum" },
                new Tag { Id = 6, Name = "Spolupráce" },
                new Tag { Id = 7, Name = "Akce" },
                new Tag { Id = 8, Name = "Mezinárodní" },
                new Tag { Id = 9, Name = "Technologie" },
                new Tag { Id = 10, Name = "Vzdělávání" }
            };
        }
    }
}
