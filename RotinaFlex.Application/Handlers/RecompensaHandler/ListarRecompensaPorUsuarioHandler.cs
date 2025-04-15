using MediatR;
using RotinaFlex.Application.Queries.RecompensaQueries;
using RotinaFlex.Application.Queries.TarefaQueries;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.RecompensaHandler;
public class ListarRecompensaPorUsuarioIdHandler : IRequestHandler<listarRecompensaPorUsuarioIdQuerry, IEnumerable<Recompensa>>
{
    private readonly IRecompensaRepository _recompensaRepository;

    public ListarRecompensaPorUsuarioIdHandler(IRecompensaRepository recompensaRepository)
    {
        _recompensaRepository = recompensaRepository;
    }

    public async Task<IEnumerable<Recompensa>> Handle(listarRecompensaPorUsuarioIdQuerry request, CancellationToken cancellationToken)
    {
        return await _recompensaRepository.ListarRecompensasPorUsuarioId(request.UsuarioId);
    }
}
