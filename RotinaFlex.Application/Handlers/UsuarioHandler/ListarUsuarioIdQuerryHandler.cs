using MediatR;
using RotinaFlex.Application.Queries.UsuarioQueries;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.UsuarioHandler;
public class ListarUsuarioIdQueryHandler : IRequestHandler<ListarUsuarioPorIdQuery, Usuario?>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuarioIdQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<Usuario?> Handle(ListarUsuarioPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.ListarUsuarioPorIdAsync(request.UsuarioId);
    }
}


