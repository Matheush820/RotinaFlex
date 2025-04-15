using FluentValidation;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Validacoes;
public class RelatorioValidacao : AbstractValidator<Relatorio>
{
    public RelatorioValidacao()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("O campo UsuarioId é obrigatório.");

        RuleFor(x => x.Periodo)
            .Null()
            .WithMessage("O campo Periodo não deve ser informado.");

        RuleFor(x => x.TarefasConcluidas)
            .NotEmpty()
            .WithMessage("O campo TarefasConcluidas é obrigatório.");

        RuleFor(x => x.PontosAcumuldos)
            .Null()
            .WithMessage("O campo PontosAcumuldos não deve ser informado.");
    }
}
