using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTB.Zpravodajstvi.Infrastructure.Database.Seeding
{
    internal class UserRolesInit
    {
        public List<IdentityUserRole<int>> GetRolesForAdmin()
        {
            List<IdentityUserRole<int>> adminUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 3
                }
            };
            return adminUserRoles;
        }
        public List<IdentityUserRole<int>> GetRolesForWriter()
        {
            List<IdentityUserRole<int>> writerUserRoles = new List<IdentityUserRole<int>>()
            {
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 3
                }
            };
            return writerUserRoles;
        }
    }
}
