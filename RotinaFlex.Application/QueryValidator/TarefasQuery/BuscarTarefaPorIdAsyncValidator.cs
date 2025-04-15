using FluentValidation;
using RotinaFlex.Application.Queries.TarefaQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.QueryValidator.TarefasQuery;
public class BuscarTarefaPorIdAsyncValidator : AbstractValidator<BuscarTarefaPorIdAsync>
{
    public BuscarTarefaPorIdAsyncValidator()
    {
        RuleFor(x => x.tarefaId)
            .NotEmpty()
            .WithMessage("Para listar uma tarefa é necessario o Id dela");
    }
}
