using Confitec.Core.Entities;
using Confitec.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.CadastrarUsuario
{
    public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand, int>
    {

        private readonly IUsuarioRepository _repository;

        public CadastrarUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = new Usuario(request.Nome, request.Sobrenome, request.Email, request.DataNascimento, request.Escolaridade);
            await _repository.AdicionarAsync(user);
            return user.Id;
        }
    }
}
