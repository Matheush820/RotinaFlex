using FluentValidation;
using RotinaFlex.Application.Commands.RecompensaCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.RecompensaCommandValidator;
public class CriarRecompensaCommandValidator : AbstractValidator<CriarRecompensaCommand>
{
    public CriarRecompensaCommandValidator()
    {
        RuleFor(x => x.Nome)
          .NotEmpty()
          .WithMessage("O campo Nome é obrigatório.")
          .MaximumLength(100)
          .WithMessage("O campo Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("O campo UsuarioId deve ser informado para poder atribuir uma recompensa.");

        RuleFor(x => x.PontosNecessarios)
            .NotEmpty()
            .WithMessage("O campo PontosNecessarios é obrigatório.")
            .GreaterThanOrEqualTo(0)
            .WithMessage("O campo PontosNecessarios deve ser maior ou igual a zero.");

    }
}
