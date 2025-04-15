using FluentValidation;
using RotinaFlex.Application.Queries.RecompensaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.QueryValidator.RecompensaQuery.RecompensaQuery;
public class ListarRecompensaPorUsuarioIdQueryValidator : AbstractValidator<listarRecompensaPorUsuarioIdQuerry>
{
    public ListarRecompensaPorUsuarioIdQueryValidator()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("Necessario um usuario para listar as recompensas");
    }
}
