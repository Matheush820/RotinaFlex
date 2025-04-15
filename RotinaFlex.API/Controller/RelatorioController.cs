using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotinaFlex.Application.Queries.RelatorioQueries;

namespace RotinaFlex.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class RelatorioController : ControllerBase
{
    private readonly IMediator _mediator;

    public RelatorioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{usuarioId}")]
    public async Task<IActionResult> GerarRelatorio(Guid usuarioId, DateTime? dataInicio = null, DateTime? dataFim = null)
    {
        var query = new GerarRelatorioQuery(usuarioId, dataInicio, dataFim);
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
