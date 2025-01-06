using System.Diagnostics.CodeAnalysis;
using Domain.Handler;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ExcludeFromCodeCoverage]
[ApiController]
[Route("[controller]")]
public class TranslateController(ITranslateHandler handler) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(TranslateResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> TranslateDefaultAsync(
        [FromQuery] TranslateRequest request, CancellationToken cancellationToken)
    {
        var response = await handler.TranslateAsync(request, cancellationToken);
        return Ok(response);
    }
}