using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Domain.Entities.Interfaces;

namespace UTB.Zpravodajstvi.Infrastructure.Identity
{
    /// <summary>
    /// Our User class which can be modified
    /// </summary>
    public class User : IdentityUser<int>, IUser<int>
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
    }
}