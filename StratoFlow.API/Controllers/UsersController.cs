using Microsoft.AspNetCore.Mvc;

namespace StratoFlow.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok("Users endpoint is working!");
    }
}