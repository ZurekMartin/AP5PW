using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Infrastructure.Identity;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class SecurityIdentityService : ISecurityService
    {
        UserManager<User> userWriter;
        public SecurityIdentityService(UserManager<User> userWriter)
        {
            this.userWriter = userWriter;
        }
        public Task<User> FindUserByEmail(string email)
        {
            return userWriter.FindByEmailAsync(email);
        }
        public Task<User> FindUserByUsername(string username)
        {
            return userWriter.FindByNameAsync(username);
        }
        public Task<IList<string>> GetUserRoles(User user)
        {
            return userWriter.GetRolesAsync(user);
        }
        public Task<User> GetCurrentUser(ClaimsPrincipal principal)
        {
            return userWriter.GetUserAsync(principal);
        }
    }
}
