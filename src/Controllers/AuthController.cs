using LicitaRadarApi.DTO;
using LicitaRadarApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }
    [HttpPost]
    public async Task<IActionResult> Login(DtoLoginRequest dto)
    {
        object resp = await _authService.Login(dto);
        return Ok(resp);
    }
}