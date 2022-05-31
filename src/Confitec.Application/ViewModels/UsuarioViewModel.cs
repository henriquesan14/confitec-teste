using Confitec.Core.Enums;
using System;

namespace Confitec.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade, DateTime? criadoEm, DateTime? atualizadoEm)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
            CriadoEm = criadoEm;
            AtualizadoEm = atualizadoEm;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }

        public DateTime? CriadoEm { get; set; }

        public DateTime? AtualizadoEm { get; set; }
    }
}
