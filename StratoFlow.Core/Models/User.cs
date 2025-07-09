// StratoFlow.Core/Models/User.cs
namespace StratoFlow.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLoginAt { get; set; }
        public bool IsActive { get; set; }
        
        // Display properties for demo purposes
        public string FullName => $"{FirstName} {LastName}";
        public string RoleDescription => Role switch
        {
            UserRole.Admin => "System Administrator",
            UserRole.User => "Standard User", 
            UserRole.Guest => "Guest Access",
            _ => "Unknown"
        };
    }
}