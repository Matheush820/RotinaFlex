using MediatR;
using RotinaFlex.Application.Queries.TarefaQueries;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Infra.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.TarefasHandler
{
    public class ListarTarefaPorUsuarioHandler : IRequestHandler<BuscarTarefaPorIdAsync, Tarefas>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public ListarTarefaPorUsuarioHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Tarefas> Handle(BuscarTarefaPorIdAsync request, CancellationToken cancellationToken)
        {
            return await _tarefaRepository.BuscarTarefaPorIdAsync(request.tarefaId);
        }
    }
}
