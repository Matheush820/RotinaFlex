using MediatR;
using RotinaFlex.Domain.MensagemGenerica;

public record AtualizarRecompensaCommand(Guid RecompensaId, string Nome, int PontosNecessarios, bool Resgatado) : IRequest<MensagemGenerica>;
