using Microsoft.AspNetCore.Mvc;

namespace BiddingProcesses.Controller;

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