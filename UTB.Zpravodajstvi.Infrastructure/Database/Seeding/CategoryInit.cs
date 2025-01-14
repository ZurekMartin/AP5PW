using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class CategoryInit
    {
        public IList<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Studium" },
                new Category { Id = 2, Name = "Věda a výzkum" },
                new Category { Id = 3, Name = "Kultura" },
                new Category { Id = 4, Name = "Sport" },
                new Category { Id = 5, Name = "Univerzitní život" },
                new Category { Id = 6, Name = "Mezinárodní" },
                new Category { Id = 7, Name = "Technologie" },
                new Category { Id = 8, Name = "Události" }
            };
        }
    }
}
