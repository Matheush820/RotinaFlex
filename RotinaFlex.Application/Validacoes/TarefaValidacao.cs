using FluentValidation;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Validacoes;
public class TarefaValidacao : AbstractValidator<Tarefas>
{
    public TarefaValidacao()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("O campo UsuarioId é obrigatório.");

        RuleFor(x => x.Titulo)
            .Null()
            .WithMessage("O campo Titulo não deve ser informado.");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("O campo Descricao é obrigatório.")
            .MaximumLength(500)
            .WithMessage("O campo Descricao deve ter no máximo 500 caracteres.");

        RuleFor(x => x.Categoria)
            .Empty()
            .WithMessage("O campo Categoria não deve ser informado.");

        RuleFor(x => x.DataHora)
            .NotEmpty()
            .WithMessage("O campo DataHora é obrigatório.");

        RuleFor(x => x.Recorrencia)
            .Empty()
            .WithMessage("O campo Recorrencia não deve ser informado.");
    }
}
