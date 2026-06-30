using LicitaRadarApi.DTO;
using LicitaRadarApi.Extensions;
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


    [HttpGet]
    public async Task<IActionResult> Read()
    {
        int userId = User.GetUserId();
        var res = await _userservice.GetUserById(userId);

        return Ok(res);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(DtoUser user)
    {
        object res = await _userservice.CreateUser(user);
        return Created(string.Empty,res);
    }


    [HttpPatch]
    public async Task<IActionResult> Update(UpdateDtoUser user)
    {
        int userId = User.GetUserId();
        await _userservice.Update(userId, user);

        return Ok(new
        {
            message = "Usuário atualizado com sucesso"
        });
    }


    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        int userId = User.GetUserId();
        await _userservice.DeleteUser(userId);
        return NoContent();
    }
}