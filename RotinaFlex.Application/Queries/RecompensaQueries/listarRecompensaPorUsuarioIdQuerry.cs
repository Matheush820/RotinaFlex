using MediatR;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Queries.RecompensaQueries;
public record listarRecompensaPorUsuarioIdQuerry(Guid UsuarioId) : IRequest<IEnumerable<Recompensa>>
{
}
