// StratoFlow.Core/Services/DemoUserService.cs
using StratoFlow.Core.Models;

namespace StratoFlow.Core.Services
{
    public class DemoUserService : IDemoUserService
    {
        private readonly List<User> _demoUsers;

        public DemoUserService()
        {
            _demoUsers = InitializeDemoUsers();
        }

        private List<User> InitializeDemoUsers()
        {
            var baseDate = DateTime.UtcNow.AddDays(-30);
            
            return new List<User>
            {
                // Admin user for testing and maintenance
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "admin",
                    Email = "admin@stratoflow.dev",
                    FirstName = "System",
                    LastName = "Administrator",
                    Role = UserRole.Admin,
                    CreatedAt = baseDate,
                    LastLoginAt = DateTime.UtcNow.AddHours(-2),
                    IsActive = true
                },
                
                // Standard user for project demo (simulating IT credentials)
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "jsmith",
                    Email = "john.smith@company.com",
                    FirstName = "John",
                    LastName = "Smith",
                    Role = UserRole.User,
                    CreatedAt = baseDate.AddDays(5),
                    LastLoginAt = DateTime.UtcNow.AddHours(-4),
                    IsActive = true
                },
                
                // Additional standard user for variety
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "mjohnson",
                    Email = "mary.johnson@company.com",
                    FirstName = "Mary",
                    LastName = "Johnson",
                    Role = UserRole.User,
                    CreatedAt = baseDate.AddDays(7),
                    LastLoginAt = DateTime.UtcNow.AddDays(-1),
                    IsActive = true
                },
                
                // Guest user for hiring managers to explore
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "guest",
                    Email = "guest@stratoflow.demo",
                    FirstName = "Guest",
                    LastName = "User",
                    Role = UserRole.Guest,
                    CreatedAt = baseDate.AddDays(10),
                    LastLoginAt = DateTime.UtcNow.AddMinutes(-30),
                    IsActive = true
                },
                
                // Inactive user for demonstration purposes
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "rmorgan",
                    Email = "robert.morgan@company.com",
                    FirstName = "Robert",
                    LastName = "Morgan",
                    Role = UserRole.User,
                    CreatedAt = baseDate.AddDays(2),
                    LastLoginAt = DateTime.UtcNow.AddDays(-14),
                    IsActive = false
                }
            };
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _demoUsers.OrderBy(u => u.Username);
        }

        public User? GetUserById(Guid id)
        {
            return _demoUsers.FirstOrDefault(u => u.Id == id);
        }

        public User? GetUserByUsername(string username)
        {
            return _demoUsers.FirstOrDefault(u => 
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<User> GetUsersByRole(UserRole role)
        {
            return _demoUsers.Where(u => u.Role == role).OrderBy(u => u.Username);
        }
    }
}
