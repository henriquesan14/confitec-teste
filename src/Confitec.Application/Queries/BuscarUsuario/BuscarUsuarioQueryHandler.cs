using AutoMapper;
using Confitec.Application.ViewModels;
using Confitec.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.BuscarUsuario
{
    public class BuscarUsuarioQueryHandler : IRequestHandler<BuscarUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _userRepository;
        private readonly IMapper _mapper;
        public BuscarUsuarioQueryHandler(IUsuarioRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UsuarioViewModel> Handle(BuscarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.BuscarPorIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UsuarioViewModel>(user);
        }
    }
}
