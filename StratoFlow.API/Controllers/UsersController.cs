// StratoFlow.API/Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using StratoFlow.Core.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return Ok(new[]
        {
            new User { Id = Guid.NewGuid(), Username = "admin", Role = "Admin" },
            new User { Id = Guid.NewGuid(), Username = "jane.doe", Role = "User" }
        });
    }
}