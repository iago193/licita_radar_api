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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var res = await _userservice.getById(id);

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> create(DtoUser user)
    {
        var validator = new CreateUserRequestValidator();
        var result = validator.Validate(user);

        if (!result.IsValid) return BadRequest(result.Errors.Select(e => e.ErrorMessage));

        object res = await _userservice.createUser(user);
        return Ok(res);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser(int id)
    {

        return Ok();
    }
}