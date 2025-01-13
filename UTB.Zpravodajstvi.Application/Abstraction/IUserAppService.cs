using UTB.Zpravodajstvi.Infrastructure.Identity;

namespace UTB.Zpravodajstvi.Application.Abstraction
{
    public interface IUserAppService
    {
        IList<User> Select();
        User GetById(int id);
        bool Update(User user);
        bool Delete(int id);
        bool ChangeRole(int userId, string newRole);
    }
} 