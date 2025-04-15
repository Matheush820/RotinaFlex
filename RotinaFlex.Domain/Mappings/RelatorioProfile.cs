using AutoMapper;
using RotinaFlex.Domain.Dtos;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Domain.Mappings;
public class RelatorioProfile : Profile
{
    public RelatorioProfile()
    {
        CreateMap<RelatorioDTO, Relatorio>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // ID será gerado no construtor
            .ForMember(dest => dest.UsuarioId, opt => opt.Ignore()) // Passa manualmente
            .ForMember(dest => dest.Periodo, opt => opt.MapFrom(src =>
                CalcularPeriodo(src.PeriodoInicio, src.PeriodoFim))) // lógica personalizada
            .ForMember(dest => dest.TarefasConcluidas, opt => opt.MapFrom(src => src.TarefasConcluidas))
            .ForMember(dest => dest.PontosAcumuldos, opt => opt.MapFrom(src => src.TarefasConcluidas * 10)); // exemplo de cálculo
    }

    private Periodo CalcularPeriodo(DateTime inicio, DateTime fim)
    {
        var dias = (fim - inicio).TotalDays;
        if (dias <= 1) return Periodo.Diario;
        if (dias <= 7) return Periodo.Semanal;
        if (dias <= 31) return Periodo.Mensal;
        return Periodo.Mensal;
    }
}
