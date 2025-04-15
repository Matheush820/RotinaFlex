using MediatR;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Queries.TarefaQueries;
public record BuscarTarefaPorIdAsync(Guid tarefaId) : IRequest<Tarefas>;
