using AutoMapper;
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
        private readonly IMapper _mapper;

        public CadastrarUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Usuario>(request);
            await _repository.AdicionarAsync(user);
            return user.Id;
        }
    }
}
