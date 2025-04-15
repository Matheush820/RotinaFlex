using MediatR;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Commands.RecompensaCommand;
public record CriarRecompensaCommand(Guid UsuarioId, string Nome, int PontosNecessarios, bool Resgatado = false) : IRequest<MensagemGenerica>
{
}
