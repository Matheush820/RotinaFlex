using FluentValidation;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Validacoes;
public class UsuarioValidacao : AbstractValidator<Usuario>
{
    public UsuarioValidacao()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("O campo Nome é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O campo Nome deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("O campo Email é obrigatório.")
            .MaximumLength(100)
            .WithMessage("O campo Email deve ter no máximo 100 caracteres.")
            .EmailAddress()
            .WithMessage("O campo Email deve ser um endereço de e-mail válido.");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("O campo Senha é obrigatório.")
            .MinimumLength(6).WithMessage("O campo Senha deve ter no mínimo 6 caracteres.")
            .MaximumLength(15).WithMessage("O campo Senha deve ter no máximo 15 caracteres.");

        RuleFor(x => x.DataCadastro)
            .NotEmpty()
            .WithMessage("O campo DataCadastro é obrigatório.");

        RuleFor(x => x.PreferenciasNotificacoes)
            .Null()
            .WithMessage("O campo PreferenciasNotificacoes não deve ser informado.");
    }
}
