using AutoMapper;
using Confitec.Application.ViewModels;
using Confitec.Application.ViewModels.Page;
using Confitec.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.BuscarTodosUsuarios
{
    public class BuscarTodosUsuariosQueryHandler : IRequestHandler<BuscarTodosUsuariosQuery, PagedListViewModel<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public BuscarTodosUsuariosQueryHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<UsuarioViewModel>> Handle(BuscarTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.BuscarTodosAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber);
            var usuariosViewModel = _mapper.Map<List<UsuarioViewModel>>(usuarios);
            return new PagedListViewModel<UsuarioViewModel>(usuariosViewModel, usuariosViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
