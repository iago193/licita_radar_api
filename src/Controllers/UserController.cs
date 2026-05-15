using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("user")]

public class User : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> create()
    {
        return Ok("Funcionando");
    }
}