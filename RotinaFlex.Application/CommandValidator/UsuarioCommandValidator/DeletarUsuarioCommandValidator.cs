using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.CommandValidator.UsuarioCommandValidator;
public class DeletarUsuarioCommandValidator : AbstractValidator<DeletarUsuarioCommand>
{
    public DeletarUsuarioCommandValidator()
    {
        RuleFor(x => x.UsuarioId)
            .NotEmpty().WithMessage("O campo UsuarioId é obrigatório.")
            .NotNull().WithMessage("O campo UsuarioId não pode ser nulo.")
            .Must(x => x != Guid.Empty).WithMessage("O campo UsuarioId não pode ser um GUID vazio.");
    }
}
