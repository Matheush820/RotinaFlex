using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotinaFlex.Infra.Interfaces;
public interface IRecompensaRepository
{
    Task <Recompensa> RecompensaPorId (Guid recompensaId);
    Task<MensagemGenerica> CriarRecompensa(Guid usuarioId, Recompensa recompensa);
    Task<MensagemGenerica> AtualizarRecompensa(Recompensa novaRecompensa);
    Task<MensagemGenerica> DeletarRecompensa(Guid recompensaId);
    Task<MensagemGenerica> ResgatarRecompensa(Guid usuarioId,Guid recompensaId);
    Task<IEnumerable<Recompensa>> ListarRecompensasPorUsuarioId(Guid usuarioId);
}
