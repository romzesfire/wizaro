using Microsoft.AspNetCore.Mvc;
using Magic.DTO.Interfaces;
using Magic.DTO.Interfaces.Providers;

namespace Magic.App.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionsController : Controller
{
    private readonly ILogger<QuestionsController> _logger;

    public QuestionsController(ILogger<QuestionsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetSuites()
    {
        return Ok();
    }
}