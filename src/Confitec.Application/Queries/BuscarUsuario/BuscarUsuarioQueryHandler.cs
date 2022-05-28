﻿using Confitec.Application.ViewModels;
using Confitec.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.BuscarUsuario
{
    public class BuscarUsuarioQueryHandler : IRequestHandler<BuscarUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _userRepository;
        public BuscarUsuarioQueryHandler(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UsuarioViewModel> Handle(BuscarUsuarioQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.ObterPorId(request.Id);

            if (user == null)
            {
                return null;
            }

            return new UsuarioViewModel(user.Nome, user.Sobrenome, user.Email, user.DataNascimento, user.Escolaridade);
        }
    }
}