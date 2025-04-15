using MediatR;
using RotinaFlex.Domain.Entities;

namespace RotinaFlex.Application.Queries.UsuarioQueries;
public record ListarUsuarioPorIdQuery(Guid UsuarioId) : IRequest<Usuario>;
