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
            IList<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Technologie"
            });
            categories.Add(new Category
            {
                Id = 2,
                Name = "Zprávy"
            });

            return categories;
        }
    }
}
