using Confitec.Application.ViewModels;
using Confitec.Core.Enums;
using System;
using System.Collections.Generic;

namespace Confitec.UnitTests.Application.Builders.ViewModels
{
    public class UsuarioViewModelBuilder
    {
        private UsuarioViewModel _usuario;

        public UsuarioViewModelBuilder SetNome(string nome)
        {
            _usuario.Nome = nome;
            return this;
        }

        public UsuarioViewModelBuilder SetSobreNome(string sobrenome)
        {
            _usuario.Sobrenome = sobrenome;
            return this;
        }

        public UsuarioViewModelBuilder SetEmail(string email)
        {
            _usuario.Email = email;
            return this;
        }

        public UsuarioViewModelBuilder SetDataNascimento(DateTime dataNascimento)
        {
            _usuario.DataNascimento = dataNascimento;
            return this;
        }

        public UsuarioViewModelBuilder SetEscolaridade(EscolaridadeEnum escolaridade)
        {
            _usuario.Escolaridade = escolaridade;
            return this;
        }

        public UsuarioViewModelBuilder Default()
        {
            _usuario = new UsuarioViewModel {
                Id = 1,
                Nome = "nome",
                Sobrenome = "sobrenome",
                Email = "email@email.com",
                DataNascimento = DateTime.Now.AddDays(-2), 
                Escolaridade = EscolaridadeEnum.FUNDAMENTAL 
            };
            return this;
        }

        public UsuarioViewModel Build()
        {
            return _usuario;
        }
    }
}
