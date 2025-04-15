using MediatR;
using RotinaFlex.Application.Commands.TarefaCommands;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.Enums;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RotinaFlex.Application.Handlers.TarefasHandler
{
    public class CriarTarefaHandler : IRequestHandler<CriarTarefaCommand, MensagemGenerica>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public CriarTarefaHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<MensagemGenerica> Handle(CriarTarefaCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Categoria: {request.Categoria}");
            Console.WriteLine($"Recorrência: {request.Recorrencia}");

            if (!Enum.IsDefined(typeof(Categoria), request.Categoria))
            {
                Console.WriteLine("Categoria inválida");
                return new MensagemGenerica(false, "Categoria inválida.");
            }

            if (!Enum.IsDefined(typeof(Recorrencia), request.Recorrencia))
            {
                Console.WriteLine("Recorrência inválida");
                return new MensagemGenerica(false, "Recorrência inválida.");
            }

            var novaTarefa = new Tarefas(
                request.UsuarioId,
                request.Titulo,
                request.Descricao,
                request.Categoria,
                request.DataHora,
                request.Recorrencia
            );

            var resultado = await _tarefaRepository.CriarTarefa(novaTarefa);
            Console.WriteLine($"Resultado: Success = {resultado.Success}, Mensagem = {resultado.Mensagem}");
            return resultado;
        }

    }
}
