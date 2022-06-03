using AutoMapper;
using Confitec.Application.Mappers;
using Confitec.Application.Queries.BuscarTodosUsuarios;
using Confitec.Application.ViewModels;
using Confitec.Application.ViewModels.Page;
using Confitec.Core.Entities;
using Confitec.Core.Enums;
using Confitec.Core.Repositories;
using Confitec.UnitTests.Application.Builders.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Confitec.UnitTests.Application.Queries
{
    public class BuscarTodosUsuariosQueryTests
    {
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly IMapper _mapper;

        public BuscarTodosUsuariosQueryTests()
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
        public async Task BuscarTodosUsuariosQuery_Executed_ReturnProjectId()
        {
            List<Usuario> usuarios = new UsuarioBuilder().Default().BuildList(10);

            _usuarioRepositoryMock.Setup(pr => pr.BuscarTodosAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(usuarios);

            var buscarUsuariosQuery = new BuscarTodosUsuariosQuery(new PageFilter { PageNumber = 1, PageSize = 10 });
            var buscarUsuariosQueryHandler = new BuscarTodosUsuariosQueryHandler(_usuarioRepositoryMock.Object, _mapper);

            // Act
            PagedListViewModel<UsuarioViewModel> usuariosViewModel = await buscarUsuariosQueryHandler.Handle(buscarUsuariosQuery, new CancellationToken());

            // Assert
            Assert.NotNull(usuariosViewModel);
            Assert.NotEmpty(usuariosViewModel.Items);
            Assert.Equal(usuarios.Count, usuariosViewModel.Items.Count());


            _usuarioRepositoryMock.Verify(pr => pr.BuscarTodosAsync(It.IsAny<int>(), It.IsAny<int>()).Result, Times.Once);
        }
    }
}
