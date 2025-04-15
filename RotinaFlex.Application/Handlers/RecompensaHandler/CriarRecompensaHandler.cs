using MediatR;
using RotinaFlex.Application.Commands.RecompensaCommand;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.RecompensaHandler;
public class CriarRecompensaHandler : IRequestHandler<CriarRecompensaCommand, MensagemGenerica>
{
    private readonly IRecompensaRepository _recompensaRepository;
    public CriarRecompensaHandler(IRecompensaRepository recompensaRepository)
    {
        _recompensaRepository = recompensaRepository;
    }
    public async Task<MensagemGenerica> Handle(CriarRecompensaCommand request, CancellationToken cancellationToken)
    {
        var recompensa = new Recompensa(request.UsuarioId, request.Nome, request.PontosNecessarios, request.Resgatado);

        return await _recompensaRepository.CriarRecompensa(request.UsuarioId, recompensa);
    }
}
