using Confitec.Core.Enums;
using MediatR;
using System;

namespace Confitec.Application.Commands.AtualizarUsuario
{
    public class AtualizarUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
