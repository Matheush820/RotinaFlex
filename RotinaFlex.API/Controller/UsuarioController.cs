using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RotinaFlex.Application.Commands.UsuarioCommands;
using RotinaFlex.Application.Queries.UsuarioQueries;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Data;

namespace RotinaFlex.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET api/Usuario/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarioPorId(Guid id)
    {
        var query = new ListarUsuarioPorIdQuery(id);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound("Usuário não encontrado");
        }

        return Ok(result); // Retorna 200 OK com o usuário
    }

    // GET api/Usuario
    [HttpGet]
    public async Task<IActionResult> GetUsuarios()
    {
        var query = new ListarUsuarioQuery();
        var result = await _mediator.Send(query);

        if (result == null || !result.Any())
        {
            return NotFound("Nenhum usuário encontrado");
        }

        return Ok(result); // Retorna 200 OK com a lista de usuários
    }

    [HttpPost]
    public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is MensagemGenerica mensagem && !mensagem.Success)
            return BadRequest(mensagem.Mensagem);

        return Created(string.Empty, result); // você pode trocar o string.Empty por uma rota, se quiser
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarUsuario(Guid id)
    {
        var command = new DeletarUsuarioCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarUsuario(Guid id, [FromBody] AtualizarUsuarioCommand command)
    {
        if (id != command.UsuarioId)
        {
            return BadRequest("ID do usuário não corresponde ao ID fornecido.");
        }
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
