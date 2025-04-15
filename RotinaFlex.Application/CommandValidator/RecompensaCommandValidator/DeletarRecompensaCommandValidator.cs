using FluentValidation;
using RotinaFlex.Application.Commands.RecompensaCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.RecompensaCommandValidator;
public class DeletarRecompensaCommandValidator : AbstractValidator<DeletarRecompensaCommand>
{
    public DeletarRecompensaCommandValidator()
    {
        RuleFor(x => x.RecompensaId).NotEmpty().WithMessage("Necessario uma recompensa para exclusão");
    }
}
