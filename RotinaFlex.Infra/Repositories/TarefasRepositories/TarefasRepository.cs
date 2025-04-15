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

namespace RotinaFlex.Infra.Repositories.TarefasRepositories;
public class TarefasRepository : ITarefaRepository
{
    private readonly AppDbContext _appDbContext;

    public TarefasRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Tarefas?> BuscarTarefaPorIdAsync(Guid tarefaId)
    {
        return await _appDbContext.Tarefas
            .Include(t => t.Usuario) // se quiser carregar dados do usuário junto
            .FirstOrDefaultAsync(t => t.Id == tarefaId);
    }

    public async Task<MensagemGenerica> CriarTarefa(Tarefas tarefa)
    {
        Console.WriteLine($"Verificando usuário: {tarefa.UsuarioId}");

        var usuarioExiste = await _appDbContext.Usuario.AnyAsync(u => u.Id == tarefa.UsuarioId);
        Console.WriteLine($"Usuário existe? {usuarioExiste}");

        if (!usuarioExiste)
        {
            Console.WriteLine("Usuário não encontrado.");
            return new MensagemGenerica(false, "Usuário não encontrado");
        }

        _appDbContext.Tarefas.Add(tarefa);
        await _appDbContext.SaveChangesAsync();

        Console.WriteLine("Tarefa criada com sucesso.");
        return new MensagemGenerica(true, "Tarefa criada com sucesso");
    }


    public async Task<MensagemGenerica> AtualizarTarefa(Guid tarefaId, Tarefas novaTarefa)
    {
        var atualizarTarefa = await _appDbContext.Tarefas
            .Include(t => t.Usuario)
            .FirstOrDefaultAsync(t => t.Id == tarefaId);

        if (atualizarTarefa == null)
            return new MensagemGenerica(false, "Tarefa não encontrada.");

        // Evita mudar o usuário diretamente se o setter for privado
        if (atualizarTarefa.UsuarioId != novaTarefa.UsuarioId)
            return new MensagemGenerica(false, "Não é permitido alterar o usuário da tarefa.");

        atualizarTarefa.Titulo = novaTarefa.Titulo;
        atualizarTarefa.Descricao = novaTarefa.Descricao;
        atualizarTarefa.DataHora = novaTarefa.DataHora;
        atualizarTarefa.Categoria = novaTarefa.Categoria;
        atualizarTarefa.Recorrencia = novaTarefa.Recorrencia;

        _appDbContext.Tarefas.Update(atualizarTarefa);
        await _appDbContext.SaveChangesAsync();

        return new MensagemGenerica(true, "Tarefa atualizada com sucesso.");
    }



    public async Task<MensagemGenerica> DeletarTarefa(Guid tarefaId)
    {
        var tarefa = await _appDbContext.Tarefas.FirstOrDefaultAsync(t => t.Id == tarefaId);

        if (tarefa == null)
            return new MensagemGenerica(false, "Tarefa não encontrada.");

        _appDbContext.Tarefas.Remove(tarefa);
        await _appDbContext.SaveChangesAsync();

        return new MensagemGenerica(true, "Tarefa deletada com sucesso.");
    }


}
