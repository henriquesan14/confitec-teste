using Confitec.Application.ViewModels;
using MediatR;

namespace Confitec.Application.Queries.BuscarUsuario
{
    public class BuscarUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public BuscarUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
