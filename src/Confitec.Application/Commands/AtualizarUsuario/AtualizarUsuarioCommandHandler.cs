using AutoMapper;
using Confitec.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public AtualizarUsuarioCommandHandler(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.BuscarPorIdAsync(request.Id);
            if(user == null)
            {
                return 0;
            }
            var userUpdate = _mapper.Map(request, user);
            await _repository.AtualizarAsync(userUpdate);
            return user.Id;
        }
    }
}
