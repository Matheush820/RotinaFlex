using MediatR;
using RotinaFlex.Application.Commands.UsuarioCommands;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.UsuarioHandler;

public class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioCommand, MensagemGenerica>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public AtualizarUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<MensagemGenerica> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
    {
        var usuarioExistente = await _usuarioRepository.ListarUsuarioPorIdAsync(request.UsuarioId);

        if (usuarioExistente == null)
        {
            return new MensagemGenerica(false, "Usuário não encontrado.");
        }

        // Atualiza os dados
        usuarioExistente.Nome = request.Nome;
        usuarioExistente.Email = request.Email;
        usuarioExistente.Senha = request.Senha;
        usuarioExistente.PreferenciasNotificacoes = request.PreferenciasNotificacoes;

        await _usuarioRepository.AtualizarUsuarioAsync(usuarioExistente.Id, usuarioExistente);

        return new MensagemGenerica(true, "Usuário atualizado com sucesso!");
    }
}
