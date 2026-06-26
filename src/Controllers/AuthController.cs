using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AuthController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login()
    {
        return Ok("Estamos aqui no login!");
    }
}