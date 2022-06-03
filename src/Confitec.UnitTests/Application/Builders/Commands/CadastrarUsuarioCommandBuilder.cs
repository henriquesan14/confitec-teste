using Confitec.Application.Commands.CadastrarUsuario;
using Confitec.Core.Entities;
using Confitec.Core.Enums;
using System;

namespace Confitec.UnitTests.Application.Builders.Commands
{
    public class CadastrarUsuarioCommandBuilder
    {
        private CadastrarUsuarioCommand _usuario;

        public CadastrarUsuarioCommandBuilder SetNome(string nome)
        {
            _usuario.Nome = nome;
            return this;
        }

        public CadastrarUsuarioCommandBuilder SetSobreNome(string sobrenome)
        {
            _usuario.Sobrenome = sobrenome;
            return this;
        }

        public CadastrarUsuarioCommandBuilder SetEmail(string email)
        {
            _usuario.Email = email;
            return this;
        }

        public CadastrarUsuarioCommandBuilder SetDataNascimento(DateTime dataNascimento)
        {
            _usuario.DataNascimento = dataNascimento;
            return this;
        }

        public CadastrarUsuarioCommandBuilder SetEscolaridade(EscolaridadeEnum escolaridade)
        {
            _usuario.Escolaridade = escolaridade;
            return this;
        }

        public CadastrarUsuarioCommandBuilder Default()
        {
            _usuario = new CadastrarUsuarioCommand
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

        public CadastrarUsuarioCommand Build()
        {
            return _usuario;
        }
    }
}
