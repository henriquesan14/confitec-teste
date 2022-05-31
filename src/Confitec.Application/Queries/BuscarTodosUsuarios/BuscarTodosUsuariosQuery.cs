using Confitec.Application.ViewModels;
using Confitec.Application.ViewModels.Page;
using MediatR;

namespace Confitec.Application.Queries.BuscarTodosUsuarios
{
    public class BuscarTodosUsuariosQuery : IRequest<PagedListViewModel<UsuarioViewModel>>
    {
        public BuscarTodosUsuariosQuery(PageFilter pageFilter)
        {
            PageFilter = pageFilter;
        }

        public PageFilter PageFilter { get; set; }
    }
}
