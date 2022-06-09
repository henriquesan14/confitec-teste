using Confitec.Application.Commands.RemoverUsuario;
using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Confitec.UnitTests.Application.Builders.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Confitec.UnitTests.Application.Commands
{
    public class RemoverUsuarioCommandHandlerTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;

        public RemoverUsuarioCommandHandlerTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
        }


        [Fact]
        public async Task DeleteUsuarioCommand_Executed_ReturnProjectId()
        {
            var deleteUsuarioCommand = new RemoverUsuarioCommand(1);

            var deleteUsuarioCommandHandler = new RemoverUsuarioCommandHandler(_usuarioRepositoryMock.Object);
            var usuario = new UsuarioBuilder().Default().Build();
            _usuarioRepositoryMock.Setup(r => r.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);
            //Act
            var id = await deleteUsuarioCommandHandler.Handle(deleteUsuarioCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            _usuarioRepositoryMock.Verify(pr => pr.RemoverAsync(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
