using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RotinaFlex.Application.Commands.RecompensaCommand;
using RotinaFlex.Application.Queries.RecompensaQueries;

namespace RotinaFlex.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class RecompensaController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecompensaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecompensaPorId(Guid id)
    {
        var query = new listarRecompensaPorUsuarioIdQuerry(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost("Resgatar")]
    public async Task<IActionResult> ResgatarRecompensa([FromQuery] Guid usuarioId, [FromQuery] Guid recompensaId)
    {
        var command = new ResgatarRecompensaCommand(usuarioId, recompensaId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }


    [HttpPost("Cria")]
    public async Task<IActionResult> CriarRecompensa([FromBody] CriarRecompensaCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            Console.WriteLine($"Error: {result.Mensagem}");
            return BadRequest(result); // Retorna erro se não for bem-sucedido
        }

        // Se foi bem-sucedido, retorna a resposta com 201 e o corpo da mensagem
        return Created("", result); // Aqui você pode passar a URL do novo recurso, caso queira
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarRecompensa(Guid id)
    {
        var command = new DeletarRecompensaCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarRecompensa(Guid id, [FromBody] AtualizarRecompensaCommand command)
    {
        if (id != command.RecompensaId)
        {
            return BadRequest("ID da recompensa não corresponde ao ID fornecido.");
        }
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
