using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Infra.Interfaces;
public interface ITarefaRepository
{
    Task<MensagemGenerica> CriarTarefa(Tarefas tarefa);
    Task<MensagemGenerica> AtualizarTarefa(Guid tarefaId, Tarefas novaTarefa);
    Task<MensagemGenerica> DeletarTarefa(Guid tarefaId);
    Task<Tarefas?> BuscarTarefaPorIdAsync(Guid tarefaId);

}
