using UTB.Zpravodajstvi.Infrastructure.Identity;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> Select();
        User GetById(int id);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
        Task<bool> ChangeRole(int userId, string newRole);
    }
} 