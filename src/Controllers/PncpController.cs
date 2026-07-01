using LicitaRadarApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace LicitaRadarApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class PncpController : ControllerBase
{
    private readonly PncpService _pncpService;

    public PncpController(PncpService pncpService)
    {
        _pncpService = pncpService;
    }

    [HttpGet]
    public async Task<IActionResult> PncpGetAll(
        [FromQuery] DateTime dataInicial,
        [FromQuery] DateTime dataFinal,
        [FromQuery] int pagina = 1
    )
    {
        var resultado = await _pncpService.SearchHiringsAsync(dataInicial, dataFinal, pagina);
        return Ok(resultado);
    }
}