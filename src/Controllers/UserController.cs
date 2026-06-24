using LicitaRadarApi.DTO;
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
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        var res = await _userservice.GetById(id);

        return Ok(res);
    }

    [HttpPost]
    public async Task<IActionResult> create(DtoUser user)
    {
        object res = await _userservice.CreateUser(user);
        return Ok(res);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser(int id, DtoUser user)
    {
        await _userservice.Update(id, user);

        return Ok(new
        {
            message = "Usuário atualizado com sucesso"
        });
    }
}