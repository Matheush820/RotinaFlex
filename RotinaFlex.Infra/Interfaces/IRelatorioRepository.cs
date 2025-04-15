using RotinaFlex.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Infra.Interfaces;
public interface IRelatorioRepository
{
    Task<RelatorioDTO> GerarRelatorioAsync(Guid usuarioId, DateTime? dataInicio = null, DateTime? dataFim = null);
}
