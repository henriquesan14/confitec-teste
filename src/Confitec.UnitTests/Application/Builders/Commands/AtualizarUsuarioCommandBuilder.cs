using Confitec.Application.Commands.AtualizarUsuario;
using Confitec.Core.Enums;
using System;

namespace Confitec.UnitTests.Application.Builders.Commands
{
    public class AtualizarUsuarioCommandBuilder
    {
        private AtualizarUsuarioCommand _usuario;

        public AtualizarUsuarioCommandBuilder SetNome(string nome)
        {
            _usuario.Nome = nome;
            return this;
        }

        public AtualizarUsuarioCommandBuilder SetSobreNome(string sobrenome)
        {
            _usuario.Sobrenome = sobrenome;
            return this;
        }

        public AtualizarUsuarioCommandBuilder SetEmail(string email)
        {
            _usuario.Email = email;
            return this;
        }

        public AtualizarUsuarioCommandBuilder SetDataNascimento(DateTime dataNascimento)
        {
            _usuario.DataNascimento = dataNascimento;
            return this;
        }

        public AtualizarUsuarioCommandBuilder SetEscolaridade(EscolaridadeEnum escolaridade)
        {
            _usuario.Escolaridade = escolaridade;
            return this;
        }

        public AtualizarUsuarioCommandBuilder Default()
        {
            _usuario = new AtualizarUsuarioCommand
            {
                Id = 1,
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email@email.com",
                DataNascimento = DateTime.Now.AddDays(-2),
                Escolaridade = EscolaridadeEnum.FUNDAMENTAL
            };
            return this;
        }

        public AtualizarUsuarioCommand Build()
        {
            return _usuario;
        }
    }
}
