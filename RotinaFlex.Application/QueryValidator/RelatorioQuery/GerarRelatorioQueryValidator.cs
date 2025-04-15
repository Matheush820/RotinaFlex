using FluentValidation;
using RotinaFlex.Application.Queries.RelatorioQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.QueryValidator.RelatorioQuery;
public class GerarRelatorioQueryValidator : AbstractValidator<GerarRelatorioQuery>
{
    public GerarRelatorioQueryValidator()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("O campo UsuarioId é obrigatório.");
        RuleFor(x => x.DataInicio)
            .NotEmpty()
            .WithMessage("O campo DataInicio é obrigatório.");
        RuleFor(x => x.DataFim)
            .NotEmpty()
            .WithMessage("O campo DataFim é obrigatório.");
    }
}

