using Microsoft.EntityFrameworkCore;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Data;
using RotinaFlex.Infra.Interfaces;

namespace RotinaFlex.Infra.Repositories.UsuarioRepositories;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _appDbContext;

    public UsuarioRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Usuario?> ListarUsuarioPorIdAsync(Guid usuarioId)
    {
        // Incluindo tanto as recompensas quanto as tarefas associadas
        return await _appDbContext.Usuario
            .Include(u => u.Recompensas)  // Carregar as recompensas associadas ao usuário
            .Include(u => u.Tarefas)     // Carregar as tarefas associadas ao usuário
            .FirstOrDefaultAsync(u => u.Id == usuarioId);
    }

    public async Task<IEnumerable<Usuario>> ListarUsuariosAsync()
    {
        return await _appDbContext.Usuario
            .Include(u => u.Recompensas)  // Carregar as recompensas associadas ao usuário
            .Include(u => u.Tarefas)     // Carregar as tarefas associadas ao usuário
            .ToListAsync();
    }


    public async Task<MensagemGenerica> CriarUsuarioAsync(Usuario usuario)
    {
        var usuarioExistente = await _appDbContext.Usuario
            .FirstOrDefaultAsync(u => u.Email == usuario.Email); // <-- email como critério de unicidade

        if (usuarioExistente != null)
            return new MensagemGenerica(false, "Email já cadastrado");

        _appDbContext.Usuario.Add(usuario);
        await _appDbContext.SaveChangesAsync();
        return new MensagemGenerica(true, "Usuário criado com sucesso");
    }


    public async Task<MensagemGenerica> AtualizarUsuarioAsync(Guid usuarioId, Usuario novoUsuario)
    {
        var atualizarUsuario = await _appDbContext.Usuario
            .Include(u => u.Recompensas) // Importante para carregar recompensas existentes
            .FirstOrDefaultAsync(u => u.Id == usuarioId);

        if (atualizarUsuario == null)
            return new MensagemGenerica(false, "Erro ao atualizar Usuario");

        // Atualiza dados básicos do usuário
        atualizarUsuario.Nome = novoUsuario.Nome;
        atualizarUsuario.Email = novoUsuario.Email;
        atualizarUsuario.Senha = novoUsuario.Senha;

        // Sincroniza recompensas
        var recompensasAtuais = atualizarUsuario.Recompensas.ToList();
        var novasRecompensas = novoUsuario.Recompensas.ToList();

        // Remove recompensas que não existem mais
        foreach (var antiga in recompensasAtuais)
        {
            if (!novasRecompensas.Any(n => n.Id == antiga.Id))
            {
                _appDbContext.Entry(antiga).State = EntityState.Deleted;
            }
        }

        // Atualiza recompensas existentes e adiciona novas
        foreach (var nova in novasRecompensas)
        {
            var existente = recompensasAtuais.FirstOrDefault(r => r.Id == nova.Id);
            if (existente != null)
            {
                existente.Nome = nova.Nome;
                existente.PontosNecessarios = nova.PontosNecessarios;
                existente.Resgatado = nova.Resgatado;
            }
            else
            {
                atualizarUsuario.Recompensas.Add(new Recompensa(
                    atualizarUsuario.Id,
                    nova.Nome,
                    nova.PontosNecessarios,
                    nova.Resgatado
                ));
            }
        }

        _appDbContext.Usuario.Update(atualizarUsuario);
        await _appDbContext.SaveChangesAsync();

        return new MensagemGenerica(true, "Usuário atualizado com sucesso");
    }
    public async Task<MensagemGenerica> DeletarUsuarioAsync(Guid usuarioId)
    {
        var deletarUsuario = await _appDbContext.Usuario
            .FirstOrDefaultAsync(u => u.Id == usuarioId);
        if (deletarUsuario != null)
        {
            _appDbContext.Usuario.Remove(deletarUsuario);
            await _appDbContext.SaveChangesAsync();
            return new MensagemGenerica(true, "Usuario deletado com sucesso");
        }

        return new MensagemGenerica(false, "Erro ao deletar Usuario");
    }

  
}
