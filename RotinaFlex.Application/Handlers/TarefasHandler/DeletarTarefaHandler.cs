using MediatR;
using RotinaFlex.Application.Commands.TarefaCommands;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.TarefasHandler;
public class DeletarTarefaHandler : IRequestHandler<DeletarTarefaCommand, MensagemGenerica>
{
    private readonly ITarefaRepository _tarefaRepository;

    public DeletarTarefaHandler(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<MensagemGenerica> Handle(DeletarTarefaCommand request, CancellationToken cancellationToken)
    {
        return await _tarefaRepository.DeletarTarefa(request.tarefaId);
    }
}
