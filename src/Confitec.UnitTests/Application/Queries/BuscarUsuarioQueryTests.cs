using AutoMapper;
using Confitec.Application.Mappers;
using Confitec.Application.Queries.BuscarUsuario;
using Confitec.Core.Entities;
using Confitec.Core.Enums;
using Confitec.Core.Repositories;
using Confitec.UnitTests.Application.Builders.Entities;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Confitec.UnitTests.Application.Queries
{
    public class BuscarUsuarioQueryTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly IMapper _mapper;

        public BuscarUsuarioQueryTests()
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
        public async Task BuscarUsuarioQuery_Executed_ReturnProjectId()
        {
            var usuario = new UsuarioBuilder().Default().Build();

            _usuarioRepositoryMock.Setup(pr => pr.BuscarPorIdAsync(It.IsAny<int>())).ReturnsAsync(usuario);

            var buscarUsuarioQuery = new BuscarUsuarioQuery(1);
            var buscarUsuarioQueryHandler = new BuscarUsuarioQueryHandler(_usuarioRepositoryMock.Object, _mapper);

            // Act
            var usuarioViewModel = await buscarUsuarioQueryHandler.Handle(buscarUsuarioQuery, new CancellationToken());

            // Assert
            Assert.NotNull(usuarioViewModel);
            Assert.NotEqual(usuarioViewModel.Id, 0);

            _usuarioRepositoryMock.Verify(pr => pr.BuscarPorIdAsync(1).Result, Times.Once);
        }
    }
}
