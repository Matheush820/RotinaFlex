using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Commands.UsuarioCommands;
public record AtualizarUsuarioCommand(
    Guid UsuarioId,
    string Nome,
    string Email,
    string Senha,
    bool PreferenciasNotificacoes
) : IRequest<MensagemGenerica>;


