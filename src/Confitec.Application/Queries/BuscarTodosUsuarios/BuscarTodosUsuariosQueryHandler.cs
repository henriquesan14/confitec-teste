using Confitec.Application.ViewModels;
using Confitec.Application.ViewModels.Page;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.BuscarTodosUsuarios
{
    public class BuscarTodosUsuariosQueryHandler : IRequestHandler<BuscarTodosUsuariosQuery, PagedListViewModel<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _repository;

        public BuscarTodosUsuariosQueryHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedListViewModel<UsuarioViewModel>> Handle(BuscarTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repository.BuscarTodosAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber);
            var usuariosViewModel = new List<UsuarioViewModel>();
            foreach(var u in usuarios)
            {
                usuariosViewModel.Add(new UsuarioViewModel(u.Id, u.Nome, u.Sobrenome, u.Email, u.DataNascimento, u.Escolaridade, u.CriadoEm, u.AtualizadoEm));
            }
            return new PagedListViewModel<UsuarioViewModel>(usuariosViewModel, usuariosViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
