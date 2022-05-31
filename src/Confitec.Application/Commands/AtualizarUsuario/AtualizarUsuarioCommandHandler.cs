using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.Id,request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);
            await _repository.AtualizarAsync(user);
            return user.Id;
        }
    }
}
