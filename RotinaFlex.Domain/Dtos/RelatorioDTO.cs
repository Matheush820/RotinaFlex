using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Domain.Dtos;
public class RelatorioDTO
{
    public DateTime PeriodoInicio { get; set; }
    public DateTime PeriodoFim { get; set; }
    public int TotalTarefas { get; set; }
    public int TarefasConcluidas { get; set; }
    public int TarefasPendentes { get; set; }
    public int TarefasExpiradas { get; set; }
    public Dictionary<string, int> TarefasPorCategoria { get; set; } // Ex: "Estudos" -> 5 tarefas
}
