using AutoMapper;
using Confitec.Application.Commands.CadastrarUsuario;
using Confitec.Application.Mappers;
using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using Confitec.UnitTests.Application.Builders.Commands;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Confitec.UnitTests.Application.Commands
{
    public class CadastrarUsuarioCommandHandlerTests
    {

        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly IMapper _mapper;

        public CadastrarUsuarioCommandHandlerTests()
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
        public async Task CreateUsuarioCommand_Executed_ReturnProjectId()
        {
            var createUsuarioCommand = new CadastrarUsuarioCommandBuilder().Default().Build();

            var createUsuarioCommandHandler = new CadastrarUsuarioCommandHandler(_usuarioRepositoryMock.Object, _mapper);

            //Act
            var id = await createUsuarioCommandHandler.Handle(createUsuarioCommand, new CancellationToken());

            //Assert
            Assert.True(id >= 0);

            _usuarioRepositoryMock.Verify(pr => pr.AdicionarAsync(It.IsAny<Usuario>()), Times.Once);
        }
    }
}
