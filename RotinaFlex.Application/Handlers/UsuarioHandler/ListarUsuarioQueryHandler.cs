using MediatR;
using RotinaFlex.Application.Queries.UsuarioQueries;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.UsuarioHandler;
public class ListarUsuarioQueryHandler : IRequestHandler<ListarUsuarioQuery, IEnumerable<Usuario>>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public ListarUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<Usuario>> Handle(ListarUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _usuarioRepository.ListarUsuariosAsync();
    }
}

