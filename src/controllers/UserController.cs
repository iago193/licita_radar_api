using LicitaRadarApi.Model;
using LicitaRadarApi.Service;

using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("user")]

public class UserController : ControllerBase
{
    private readonly UserService _userservice;

    public UserController(UserService userService)
    {
        _userservice = userService;
    }

    [HttpPost]
    public async Task<IActionResult> create(UserModel user)
    {
        string res = await _userservice.createUser(user);
        return Ok(res);
    }
}