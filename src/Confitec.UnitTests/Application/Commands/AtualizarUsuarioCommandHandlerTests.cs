using AutoMapper;
using Confitec.Application.Commands.AtualizarUsuario;
using Confitec.Application.Mappers;
using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Confitec.UnitTests.Application.Builders.Commands;
using Confitec.UnitTests.Application.Builders.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Confitec.UnitTests.Application.Commands
{
    public class AtualizarUsuarioCommandHandlerTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly IMapper _mapper;

        public AtualizarUsuarioCommandHandlerTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UsuarioMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }


        [Fact]
        public async Task UpdateUsuarioCommand_Executed_ReturnProjectId()
        {
            var updateUsuarioCommand = new AtualizarUsuarioCommandBuilder().Default().Build();

            var updateUsuarioCommandHandler = new AtualizarUsuarioCommandHandler(_usuarioRepositoryMock.Object, _mapper);
            var usuario = new UsuarioBuilder().Default().Build();
            _usuarioRepositoryMock.Setup(r => r.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);
            //Act
            var id = await updateUsuarioCommandHandler.Handle(updateUsuarioCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            _usuarioRepositoryMock.Verify(pr => pr.AtualizarAsync(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
