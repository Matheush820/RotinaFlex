using MediatR;
using RotinaFlex.Application.Commands.RecompensaCommand;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.RecompensaHandler;
public class DeletarRecompensaHandler : IRequestHandler<DeletarRecompensaCommand, MensagemGenerica>
{
    private readonly IRecompensaRepository _recompensaRepository;

    public DeletarRecompensaHandler(IRecompensaRepository recompensaRepository)
    {
        _recompensaRepository = recompensaRepository;
    }
    public async Task<MensagemGenerica> Handle(DeletarRecompensaCommand request, CancellationToken cancellationToken)
    {
        return await _recompensaRepository.DeletarRecompensa(request.RecompensaId);
    }
}
