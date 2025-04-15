using MediatR;
using RotinaFlex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Queries.UsuarioQueries;
public record ListarUsuarioQuery() : IRequest<IEnumerable<Usuario>>;
