using FluentValidation;
using RotinaFlex.Application.Commands.UsuarioCommands;

namespace RotinaFlex.Application.CommandValidator.UsuarioCommandValidator
{
    public class AtualizarUsuarioCommandValidator : AbstractValidator<AtualizarUsuarioCommand>
    {
        public AtualizarUsuarioCommandValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty()
                .WithMessage("O ID do usuário é obrigatório.");

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
                .MinimumLength(6)
                .WithMessage("O campo Senha deve ter no mínimo 6 caracteres.")
                .MaximumLength(15)
                .WithMessage("O campo Senha deve ter no máximo 15 caracteres.");

            RuleFor(x => x.PreferenciasNotificacoes)
                .NotNull()
                .WithMessage("O campo PreferenciasNotificacoes é obrigatório.");
        }
    }
}
