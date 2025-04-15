using MediatR;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.RecompensaHandler
{
    public class AtualizarRecompensaHandler : IRequestHandler<AtualizarRecompensaCommand, MensagemGenerica>
    {
        private readonly IRecompensaRepository _recompensaRepository;

        public AtualizarRecompensaHandler(IRecompensaRepository recompensaRepository)
        {
            _recompensaRepository = recompensaRepository;
        }

        public async Task<MensagemGenerica> Handle(AtualizarRecompensaCommand request, CancellationToken cancellationToken)
        {
            // Primeiramente, buscamos a recompensa pelo ID
            var recompensaExistente = await _recompensaRepository.RecompensaPorId(request.RecompensaId);

            if (recompensaExistente == null)
            {
                return new MensagemGenerica(false, "Recompensa não encontrada.");
            }

            // Atualizamos a recompensa com os dados do comando
            recompensaExistente.Nome = request.Nome;
            recompensaExistente.PontosNecessarios = request.PontosNecessarios;
            recompensaExistente.Resgatado = request.Resgatado;

            // Passa a recompensa atualizada para o repositório
            return await _recompensaRepository.AtualizarRecompensa(recompensaExistente);
        }
    }
}
