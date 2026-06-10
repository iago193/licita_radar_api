using LicitaRadarApi.DTO;
using LicitaRadarApi.Service;
using LicitaRadarApi.Validators;
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
    public async Task<IActionResult> create(DtoUser user)
    {
        var validator = new CreateUserRequestValidator();
        var result = validator.Validate(user);

        if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

        string res = await _userservice.createUser(user);
        return Ok(res);
    }
}