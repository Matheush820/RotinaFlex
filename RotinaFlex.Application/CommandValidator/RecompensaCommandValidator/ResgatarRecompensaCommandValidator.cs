using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.RecompensaCommandValidator;
public class ResgatarRecompensaCommandValidator : AbstractValidator<ResgatarRecompensaCommand>
{
    public ResgatarRecompensaCommandValidator()
    {
        RuleFor(x => x.usuarioId)
            .NotEmpty()
            .WithMessage("Necessario um usuario para resgatar uma recompensa");

        RuleFor(x => x.RecompensaId)
            .NotEmpty()
            .WithMessage("Necessario uma recompensa para poder resgatar essa recompensa");
    }
}
