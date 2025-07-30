// StratoFlow.API/Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StratoFlow.Core.Models;
using StratoFlow.Core.Services;
using StratoFlow.Core.DTOs;
using StratoFlow.Core.Data;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IDemoUserService _userService;

    public UsersController(IDemoUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Get all users in the system
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    /// <summary>
    /// Get a specific user by ID
    /// </summary>
    /// <param name="id">User ID</param>
    [HttpGet("{id:guid}")]
    public ActionResult<User> GetUserById(Guid id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound($"User with ID {id} not found.");
        }
        return Ok(user);
    }

    /// <summary>
    /// Get a specific user by username
    /// </summary>
    /// <param name="username">Username</param>
    [HttpGet("username/{username}")]
    public ActionResult<User> GetUserByUsername(string username)
    {
        var user = _userService.GetUserByUsername(username);
        if (user == null)
        {
            return NotFound($"User with username '{username}' not found.");
        }
        return Ok(user);
    }

    /// <summary>
    /// Get users filtered by role
    /// </summary>
    /// <param name="role">User role (Admin, User, Guest)</param>
    [HttpGet("role/{role}")]
    public ActionResult<IEnumerable<User>> GetUsersByRole(string role)
    {
        if (!Enum.TryParse<UserRole>(role, true, out var userRole))
        {
            return BadRequest($"Invalid role '{role}'. Valid roles are: Admin, User, Guest");
        }

        var users = _userService.GetUsersByRole(userRole);
        return Ok(users);
    }

    /// <summary>
    /// Get demo credentials for different user types
    /// </summary>
    [HttpGet("demo-credentials")]
    public ActionResult<object> GetDemoCredentials()
    {
        return Ok(new
        {
            DemoAccounts = new[]
            {
                new { Role = "Admin", Username = "admin", Purpose = "Full system access for testing and maintenance" },
                new { Role = "User", Username = "jsmith", Purpose = "Standard user for project demonstration" },
                new { Role = "Guest", Username = "guest", Purpose = "Limited access for hiring managers to explore" }
            },
            Instructions = "Use these credentials to explore different access levels in the StratoFlow system"
        });
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDto userDto)
    {
        // Input Validation
        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = userDto.Username,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Role = userDto.Role,
            CreatedAt = DateTime.UtcNow,
            LastLoginAt = DateTime.UtcNow,
        };

        var createdUser = _userService.CreateUser(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id}, user);
    }

}