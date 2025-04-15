using Microsoft.EntityFrameworkCore;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Data;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Infra.Repositories.RecompensaRepository;
public class RecompensaRepository : IRecompensaRepository
{
    private readonly AppDbContext _context;

    public RecompensaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recompensa>> ListarRecompensasPorUsuarioId(Guid usuarioId)
    {
        return await _context.Recompensas.Where(u => u.UsuarioId == usuarioId).ToListAsync();
    }

    public async Task<Recompensa> RecompensaPorId(Guid recompensaId)
    {
        return await _context.Recompensas.FindAsync(recompensaId);
    }

    public async Task<MensagemGenerica> ResgatarRecompensa(Guid usuarioId, Guid recompensaId)
    {
        var recompensa = await _context.Recompensas
            .FirstOrDefaultAsync(r => r.Id == recompensaId && r.UsuarioId == usuarioId);

        if (recompensa == null)
            return new MensagemGenerica(false, "Recompensa não encontrada ou não pertence ao usuário.");

        recompensa.Resgatado = true;
        await _context.SaveChangesAsync();

        return new MensagemGenerica(true, "Recompensa resgatada com sucesso.");
    }

    public async Task<MensagemGenerica> CriarRecompensa(Guid usuarioId, Recompensa recompensa)
    {
        // Verifica se o usuário existe
        var usuario = await _context.Usuario.FindAsync(usuarioId);
        if (usuario == null)
        {
            return new MensagemGenerica(false, "Usuário não encontrado.");
        }

        // Verifica se a recompensa já existe para esse usuário
        var recompensaExistente = await _context.Recompensas
            .FirstOrDefaultAsync(r => r.Nome == recompensa.Nome && r.UsuarioId == usuarioId);
        if (recompensaExistente != null)
        {
            return new MensagemGenerica(false, "Recompensa já existe.");
        }

        // Cria uma nova recompensa com o usuário associado
        var novaRecompensa = new Recompensa(usuarioId, recompensa.Nome, recompensa.PontosNecessarios, recompensa.Resgatado);

        // Adiciona a recompensa ao banco de dados
        _context.Recompensas.Add(novaRecompensa);

        // Salvando as alterações no banco
        await _context.SaveChangesAsync();

        return new MensagemGenerica(true, "Recompensa criada com sucesso.");
    }



    public async Task<MensagemGenerica> AtualizarRecompensa(Recompensa novaRecompensa)
    {
        var recompensa = await _context.Recompensas.FindAsync(novaRecompensa.Id);

        if (recompensa == null)
            return new MensagemGenerica(false, "Recompensa não encontrada.");

        recompensa.Nome = novaRecompensa.Nome;
        recompensa.PontosNecessarios = novaRecompensa.PontosNecessarios;
        recompensa.Resgatado = novaRecompensa.Resgatado;

        await _context.SaveChangesAsync(); // Update() não é necessário aqui

        return new MensagemGenerica(true, "Recompensa atualizada com sucesso!");
    }




    public async Task<MensagemGenerica> DeletarRecompensa(Guid recompensaId)
    {
        var deletarRecompensa = await RecompensaPorId(recompensaId);
        if(deletarRecompensa is null)
            return new MensagemGenerica(false, "Não foi possível encontrar a recompensa para deletar.");

        _context.Recompensas.Remove(deletarRecompensa);
        await _context.SaveChangesAsync();
        return new MensagemGenerica(true, "Recompensa deletada com sucesso.");
    }

}
