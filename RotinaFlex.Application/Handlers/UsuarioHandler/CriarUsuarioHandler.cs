using MediatR;
using RotinaFlex.Application.Commands.UsuarioCommands;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.UsuarioHandler
{
    public class CriarUsuarioHandler : IRequestHandler<CriarUsuarioCommand, MensagemGenerica>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<MensagemGenerica> Handle(CriarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var novoUsuario = new Usuario(
                request.Nome,
                request.Email,
                request.Senha,
                request.PreferenciasNotificacoes
            );

            return await _usuarioRepository.CriarUsuarioAsync(novoUsuario);
        }
    }
}