using MediatR;
using RotinaFlex.Application.Queries.RelatorioQueries;
using RotinaFlex.Domain.Dtos;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.RelatorioHandler;
public class GerarRelatorioHandler : IRequestHandler<GerarRelatorioQuery, RelatorioDTO>
{
    private readonly IRelatorioRepository _relatorioRepository;

    public GerarRelatorioHandler(IRelatorioRepository relatorioRepository)
    {
        _relatorioRepository = relatorioRepository;
    }

    public async Task<RelatorioDTO> Handle(GerarRelatorioQuery request, CancellationToken cancellationToken)
    {
        return await _relatorioRepository.GerarRelatorioAsync(request.UsuarioId, request.DataInicio, request.DataFim);
    }
}
