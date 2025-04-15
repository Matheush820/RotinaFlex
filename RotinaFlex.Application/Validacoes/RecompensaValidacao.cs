using FluentValidation;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Validacoes;
public class RecompensaValidacao :  AbstractValidator<Recompensa>
{
    public RecompensaValidacao()
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
