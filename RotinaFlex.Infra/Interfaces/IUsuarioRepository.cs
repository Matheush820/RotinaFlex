using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;

namespace RotinaFlex.Infra.Interfaces;
public interface IUsuarioRepository
{
    Task<MensagemGenerica> CriarUsuarioAsync(Usuario usuario);
    Task<MensagemGenerica> AtualizarUsuarioAsync(Guid usuarioId, Usuario novoUsuario);
    Task<MensagemGenerica> DeletarUsuarioAsync(Guid usuarioId);
    Task<Usuario?> ListarUsuarioPorIdAsync(Guid usuarioId);
    Task<IEnumerable<Usuario>> ListarUsuariosAsync();
}
