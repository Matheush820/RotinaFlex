using MediatR;
using RotinaFlex.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Queries.RelatorioQueries
{
    public record GerarRelatorioQuery(Guid UsuarioId, DateTime? DataInicio = null, DateTime? DataFim = null)
        : IRequest<RelatorioDTO>;
}
