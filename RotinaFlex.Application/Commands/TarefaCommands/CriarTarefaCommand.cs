using MediatR;
using RotinaFlex.Domain.Enums;
using RotinaFlex.Domain.MensagemGenerica;
using System;

namespace RotinaFlex.Application.Commands.TarefaCommands
{
    public class CriarTarefaCommand : IRequest<MensagemGenerica>
    {
        public Guid UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataHora { get; set; }
        public Recorrencia Recorrencia { get; set; }
    }
}
