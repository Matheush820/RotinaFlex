using MediatR;
using RotinaFlex.Domain.MensagemGenerica;

public record DeletarUsuarioCommand(Guid UsuarioId) : IRequest<MensagemGenerica>;
