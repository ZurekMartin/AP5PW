using Microsoft.AspNetCore.Identity;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Infrastructure.Identity;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserAppService(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IList<User> Select()
        {
            return _userManager.Users.ToList();
        }

        public User GetById(int id)
        {
            return _userManager.Users.FirstOrDefault(u => u.Id == id);
        }

        public async bool Update(User user)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id.ToString());
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.UserName = user.UserName;

                var result = await _userManager.UpdateAsync(existingUser);
                return result.Succeeded;
            }
            return false;
        }

        public async bool Delete(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                return result.Succeeded;
            }
            return false;
        }

        public async bool ChangeRole(int userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                var result = await _userManager.AddToRoleAsync(user, newRole);
                return result.Succeeded;
            }
            return false;
        }
    }
} 