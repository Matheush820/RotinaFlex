using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.UsuarioHandler;
public class DeletarUsuarioHandler : IRequestHandler<DeletarUsuarioCommand, MensagemGenerica>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<MensagemGenerica> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.DeletarUsuarioAsync(request.UsuarioId);
    }
}

