using LicitaRadarApi.DTO;
using LicitaRadarApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]

public class UserController : ControllerBase
{
    private readonly UserService _userservice;

    public UserController(UserService userService)
    {
        _userservice = userService;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Read(int id)
    {
        var res = await _userservice.GetUserById(id);

        return Ok(res);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(DtoUser user)
    {
        object res = await _userservice.CreateUser(user);
        return Created(string.Empty,res);
    }


    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, UpdateDtoUser user)
    {
        await _userservice.Update(id, user);

        return Ok(new
        {
            message = "Usuário atualizado com sucesso"
        });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userservice.DeleteUser(id);
        return NoContent();
    }
}