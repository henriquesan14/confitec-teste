using Confitec.Core.Enums;
using System;

namespace Confitec.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
