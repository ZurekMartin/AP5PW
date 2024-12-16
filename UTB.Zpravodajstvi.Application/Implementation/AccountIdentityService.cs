using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UTB.Zpravodajstvi.Application.Abstraction;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;
using UTB.Zpravodajstvi.Infrastructure.Identity;

namespace UTB.Zpravodajstvi.Application.Implementation
{
    public class AccountIdentityService : IAccountService
    {
        UserManager<User> userWriter;
        SignInManager<User> signInWriter;
        public AccountIdentityService(UserManager<User> userWriter, SignInManager<User> signInWriter)
        {
            this.userWriter = userWriter;
            this.signInWriter = signInWriter;
        }
        public async Task<bool> Login(LoginViewModel vm)
        {
            var result = await signInWriter.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            return result.Succeeded;
        }
        public Task Logout()
        {
            return signInWriter.SignOutAsync();
        }
        public async Task<string[]> Register(RegisterViewModel vm, params Roles[] roles)
        {
            User user = new User()
            {
                UserName = vm.Username,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                PhoneNumber = vm.Phone
            };
            string[] errors = null;
            var result = await userWriter.CreateAsync(user, vm.Password);
            if (result.Succeeded)
            {
                foreach (var role in roles)
                {
                    var resultRole = await userWriter.AddToRoleAsync(user, role.ToString());
                    if (resultRole.Succeeded == false)
                    {
                        for (int i = 0; i < result.Errors.Count(); ++i)
                            result.Errors.Append(result.Errors.ElementAt(i));
                    }
                }
            }
            if (result.Errors != null && result.Errors.Count() > 0)
            {
                errors = new string[result.Errors.Count()];
                for (int i = 0; i < result.Errors.Count(); ++i)
                {
                    errors[i] = result.Errors.ElementAt(i).Description;
                }
            }
            return errors;
        }
    }
}
