using Confitec.Core.Enums;
using System;

namespace Confitec.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
