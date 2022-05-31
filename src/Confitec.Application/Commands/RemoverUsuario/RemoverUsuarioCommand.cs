using MediatR;

namespace Confitec.Application.Commands.RemoverUsuario
{
    public class RemoverUsuarioCommand : IRequest<int>
    {
        public RemoverUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
