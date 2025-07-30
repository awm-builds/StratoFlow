// StratoFlow.Core/Services/IDemoUserService.cs
using StratoFlow.Core.Models;

namespace StratoFlow.Core.Services
{
    public interface IDemoUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(Guid id);
        User? GetUserByUsername(string username);
        IEnumerable<User> GetUsersByRole(UserRole role);
        User CreateUser(User user);
        User? UpdateUser(Guid id, User user);
        bool DeleteUser(Guid id);
    }
}
