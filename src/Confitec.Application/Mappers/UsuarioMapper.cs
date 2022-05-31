using AutoMapper;
using Confitec.Application.Commands.AtualizarUsuario;
using Confitec.Application.Commands.CadastrarUsuario;
using Confitec.Application.ViewModels;
using Confitec.Core.Entities;

namespace Confitec.Application.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, CadastrarUsuarioCommand>().ReverseMap();
            CreateMap<AtualizarUsuarioCommand, Usuario>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
