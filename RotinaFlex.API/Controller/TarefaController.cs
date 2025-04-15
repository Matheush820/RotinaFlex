using MediatR;
using Microsoft.AspNetCore.Mvc;
using RotinaFlex.Application.Commands.TarefaCommands;
using RotinaFlex.Application.Queries.TarefaQueries;

namespace RotinaFlex.API.Controller;
[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly IMediator _mediator;

    public TarefaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTarefaPorUsuario(Guid id)
    {
        var query = new BuscarTarefaPorIdAsync(id);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CriarTarefa([FromBody] CriarTarefaCommand command)
    {
        Console.WriteLine($"Categoria recebida: {command.Categoria}");
        Console.WriteLine($"Recorrência recebida: {command.Recorrencia}");

        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            Console.WriteLine($"Erro: {result.Mensagem}");
            return BadRequest(result);
        }

        return Created("", result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarTarefa(Guid id)
    {
        var command = new DeletarTarefaCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(Guid id, [FromBody] AtualizarTarefaCommand command)
    {
        if (id != command.TarefaId)
            return BadRequest("ID da tarefa não corresponde ao ID fornecido.");

        var result = await _mediator.Send(command);

        if (!result.Success)
            return BadRequest(result.Mensagem);

        return Ok(result);
    }

}
