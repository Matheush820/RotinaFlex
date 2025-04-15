using FluentValidation;
using RotinaFlex.Application.Commands.TarefaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.TarefaCommandValidator;
public class CriarTarefaCommandValidator : AbstractValidator<CriarTarefaCommand>
{
    public CriarTarefaCommandValidator()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty()
            .WithMessage("UsuarioId necessario");

        RuleFor(x => x.Titulo)
            .NotEmpty()
            .WithMessage("O Titulo não pode estar vazio")
            .MinimumLength(10)
            .WithMessage("o Titulo deve contar no minimo 10 Caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("A Descrição não pode estar vazia")
            .MaximumLength(580).WithMessage("Limite maximo de caracteres atingido");

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
