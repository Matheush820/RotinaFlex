using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using System;

namespace RotinaFlex.Application.Commands.UsuarioCommands
{
    public record CriarUsuarioCommand(
        string Nome,
        string Email,
        string Senha,
        bool PreferenciasNotificacoes
    ) : IRequest<MensagemGenerica>;
}
