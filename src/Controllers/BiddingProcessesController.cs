using Microsoft.AspNetCore.Mvc;

namespace BiddingProcesses.Controllers;

[ApiController]
[Route("Licitações")]

public class BiddingProcessesController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Funcionando");
    }
}