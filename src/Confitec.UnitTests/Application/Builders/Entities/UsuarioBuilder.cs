using Confitec.Core.Entities;
using Confitec.Core.Enums;
using System;
using System.Collections.Generic;

namespace Confitec.UnitTests.Application.Builders.Entities
{
    public class UsuarioBuilder
    {
        private Usuario _usuario;

        public UsuarioBuilder SetNome(string nome)
        {
            _usuario.Nome = nome;
            return this;
        }

        public UsuarioBuilder SetSobreNome(string sobrenome)
        {
            _usuario.Sobrenome = sobrenome;
            return this;
        }

        public UsuarioBuilder SetEmail(string email)
        {
            _usuario.Email = email;
            return this;
        }

        public UsuarioBuilder SetDataNascimento(DateTime dataNascimento)
        {
            _usuario.DataNascimento = dataNascimento;
            return this;
        }

        public UsuarioBuilder SetEscolaridade(EscolaridadeEnum escolaridade)
        {
            _usuario.Escolaridade = escolaridade;
            return this;
        }

        public UsuarioBuilder Default()
        {
            _usuario = new Usuario(1, "nome", "sobrenome", "email@email.com", DateTime.Now.AddDays(-2), Core.Enums.EscolaridadeEnum.FUNDAMENTAL);
            return this;
        }

        public Usuario Build()
        {
            return _usuario;
        }

        public List<Usuario> BuildList(int size)
        {
            var list = new List<Usuario>();
            for (var i = 0; i < size; i++)
            {
                list.Add(new UsuarioBuilder().Default().Build());
            }
            return list;
        }
    }
}
