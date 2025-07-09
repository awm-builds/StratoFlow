// StratoFlow.Core/Models/UserRole.cs
namespace StratoFlow.Core.Models
{
    public enum UserRole
    {
        
        /// Full system access for testing and maintenance
        Admin,
        
        
        /// Standard user with typical business operations access (for project demo)
        User,
                
        /// Limited read-only access for hiring managers to explore the app
        Guest
    }
}
