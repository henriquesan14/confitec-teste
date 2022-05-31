using Confitec.Core.Entities.Base;
using Confitec.Core.Enums;
using System;

namespace Confitec.Core.Entities
{
    public class Usuario : Entity
    {
        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }
        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Id = id;
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
