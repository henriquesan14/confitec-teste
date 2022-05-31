using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.RemoverUsuario
{
    public class RemoverUsuarioCommandHandler : IRequestHandler<RemoverUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        public RemoverUsuarioCommandHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(RemoverUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.BuscarPorIdAsync(request.Id);
            if(user == null)
            {
                return 0;
            }
            await _repository.RemoverAsync(user);
            return user.Id;
        }
    }
}
