using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTB.Zpravodajstvi.Application.ViewModels;
using UTB.Zpravodajstvi.Infrastructure.Identity.Enums;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IAccountService
    {
        Task<bool> Login(LoginViewModel vm);
        Task Logout();
        Task<string[]> Register(RegisterViewModel vm, params Roles[] roles);
    }
}
