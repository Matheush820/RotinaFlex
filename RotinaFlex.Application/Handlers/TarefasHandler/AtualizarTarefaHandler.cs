using MediatR;
using RotinaFlex.Application.Commands.TarefaCommands;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.Enums;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Application.Handlers.TarefasHandler
{
    public class AtualizarTarefaHandler : IRequestHandler<AtualizarTarefaCommand, MensagemGenerica>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public AtualizarTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<MensagemGenerica> Handle(AtualizarTarefaCommand request, CancellationToken cancellationToken)
        {
            var tarefaAtualizada = new Tarefas(
                request.UsuarioId,
                request.Titulo,
                request.Descricao,
                Enum.Parse<Categoria>(request.Categoria),
                request.DataHora,
                Enum.Parse<Recorrencia>(request.Recorrencia)
            );

            return await _tarefaRepository.AtualizarTarefa(request.TarefaId, tarefaAtualizada);
        }
    }
}
