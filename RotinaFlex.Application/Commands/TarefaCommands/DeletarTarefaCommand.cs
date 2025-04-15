using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Commands.TarefaCommands;
public record DeletarTarefaCommand(Guid tarefaId) : IRequest<MensagemGenerica>; 
