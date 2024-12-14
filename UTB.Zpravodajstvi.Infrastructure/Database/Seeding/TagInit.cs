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
            IList<Tag> tags = new List<Tag>();

            tags.Add(new Tag
            {
                Id = 1,
                Name = "Zajímavé"
            });
            tags.Add(new Tag
            {
                Id = 2,
                Name = "Inovace"
            });

            return tags;
        }
    }
}
