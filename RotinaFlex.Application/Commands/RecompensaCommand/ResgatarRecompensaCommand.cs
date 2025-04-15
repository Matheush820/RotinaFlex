using MediatR;
using RotinaFlex.Domain.MensagemGenerica;

public record ResgatarRecompensaCommand(Guid usuarioId,Guid RecompensaId) : IRequest<MensagemGenerica>;
