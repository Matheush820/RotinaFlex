using FluentAssertions;
using Moq;
using RotinaFlex.Application.Commands.RecompensaCommand;
using RotinaFlex.Application.Handlers.RecompensaHandler;
using RotinaFlex.Domain.Entities;
using RotinaFlex.Domain.MensagemGenerica;
using RotinaFlex.Infra.Interfaces;
using Xunit;

namespace RotinaFlex.Tests.CommandsTest.RecompensaTest
{
    public class CriarRecompensaHandlerTests
    {
        [Fact]
        public async Task Handle_DeveCriarRecompensaERetornarMensagemComSucesso()
        {
            // Arrange
            var recompensaRepoMock = new Mock<IRecompensaRepository>();

            var usuarioId = Guid.NewGuid();
            var nome = "Test Recompensa";
            var pontosNecessarios = 50;
            var resgatado = false;

            var mensagemEsperada = new MensagemGenerica(true, "Recompensa criada com sucesso.");

            recompensaRepoMock
                .Setup(repo => repo.CriarRecompensa(
                    It.IsAny<Guid>(),
                    It.IsAny<Recompensa>()
                ))
                .ReturnsAsync(mensagemEsperada);

            var command = new CriarRecompensaCommand(usuarioId, nome, pontosNecessarios, resgatado);
            var handler = new CriarRecompensaHandler(recompensaRepoMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue("Esperado sucesso na criação da recompensa.");
            result.Mensagem.Should().Be("Recompensa criada com sucesso.");

            // Verifica se o método foi chamado exatamente uma vez
            recompensaRepoMock.Verify(
                repo => repo.CriarRecompensa(It.IsAny<Guid>(), It.IsAny<Recompensa>()),
                Times.Once
            );
        }
    }
}
