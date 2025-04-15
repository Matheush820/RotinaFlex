using MediatR;
using RotinaFlex.Domain.MensagemGenerica;

namespace RotinaFlex.Application.Commands.TarefaCommands
{
    public class AtualizarTarefaCommand : IRequest<MensagemGenerica>
    {
        public Guid TarefaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public DateTime DataHora { get; set; }
        public string Recorrencia { get; set; } = string.Empty;
    }
}
