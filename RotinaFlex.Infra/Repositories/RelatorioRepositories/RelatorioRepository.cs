using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RotinaFlex.Domain.Dtos;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Infra.Data;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Infra.Repositories.RelatorioRepository;

public class RelatorioRepository : IRelatorioRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public RelatorioRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<RelatorioDTO> GerarRelatorioAsync(Guid usuarioId, DateTime? dataInicio = null, DateTime? dataFim = null)
    {
        var inicio = dataInicio ?? DateTime.UtcNow.AddDays(-30);
        var fim = dataFim ?? DateTime.UtcNow;

        var tarefas = await _context.Tarefas
            .Where(t => t.UsuarioId == usuarioId && t.DataHora >= inicio && t.DataHora <= fim)
            .ToListAsync();

        var tarefasConcluidas = tarefas.Count(t => t.Recorrencia == Domain.Enums.Recorrencia.Nenhuma);
        var tarefasPendentes = tarefas.Count(t => t.DataHora > DateTime.UtcNow);
        var tarefasExpiradas = tarefas.Count(t => t.DataHora < DateTime.UtcNow && t.Recorrencia == Domain.Enums.Recorrencia.Nenhuma);

        var tarefasPorCategoria = tarefas
            .GroupBy(t => t.Categoria.ToString())
            .ToDictionary(g => g.Key, g => g.Count());

        var dto = new RelatorioDTO
        {
            PeriodoInicio = inicio,
            PeriodoFim = fim,
            TotalTarefas = tarefas.Count,
            TarefasConcluidas = tarefasConcluidas,
            TarefasPendentes = tarefasPendentes,
            TarefasExpiradas = tarefasExpiradas,
            TarefasPorCategoria = tarefasPorCategoria
        };

        // 👉 Mapeia para entidade Relatorio e salva no banco
        var relatorio = _mapper.Map<Relatorio>(dto);
        relatorio = new Relatorio(usuarioId, relatorio.Periodo, relatorio.TarefasConcluidas, relatorio.PontosAcumuldos);

        _context.Relatorio.Add(relatorio);
        await _context.SaveChangesAsync();

        return dto;
    }

}
