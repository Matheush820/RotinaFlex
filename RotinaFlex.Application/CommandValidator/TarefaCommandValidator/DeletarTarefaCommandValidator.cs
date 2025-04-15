using FluentValidation;
using RotinaFlex.Application.Commands.TarefaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.TarefaCommandValidator;
public class DeletarTarefaCommandValidator : AbstractValidator<DeletarTarefaCommand>
{
    public DeletarTarefaCommandValidator()
    {
        RuleFor(x => x.tarefaId)
            .NotEmpty()
            .WithMessage("Necessario o ID da tarefa para exclusão");
    }
}
