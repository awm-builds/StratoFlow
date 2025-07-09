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
    }
}
