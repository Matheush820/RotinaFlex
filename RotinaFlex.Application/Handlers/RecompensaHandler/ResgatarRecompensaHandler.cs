using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.RecompensaHandler;
public class ResgatarRecompensaHandler : IRequestHandler<ResgatarRecompensaCommand, MensagemGenerica>
{
    private readonly IRecompensaRepository _recompensaRepository;

    public ResgatarRecompensaHandler(IRecompensaRepository recompensaRepository)
    {
        _recompensaRepository = recompensaRepository;
    }
    public async Task<MensagemGenerica> Handle(ResgatarRecompensaCommand request, CancellationToken cancellationToken)
    {
        return await _recompensaRepository.ResgatarRecompensa(request.usuarioId, request.RecompensaId);
    }
}
