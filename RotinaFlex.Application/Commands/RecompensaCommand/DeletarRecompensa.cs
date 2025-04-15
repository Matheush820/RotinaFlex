using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Commands.RecompensaCommand;
public record  DeletarRecompensaCommand(Guid RecompensaId) : IRequest<MensagemGenerica>;
