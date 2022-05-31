using Confitec.Application.Commands.AtualizarUsuario;
using FluentValidation;
using System;

namespace Confitec.Application.Validators
{
    public class AtualizarUsuarioCommandValidator : AbstractValidator<AtualizarUsuarioCommand>
    {
        public AtualizarUsuarioCommandValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O campo Nome é obrigatório");

            RuleFor(p => p.Sobrenome)
                .NotEmpty()
                .WithMessage("O campo Sobrenome é obrigatório");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage("O campo Email é obrigatório")
                .EmailAddress()
                .WithMessage("Email não válido");

            RuleFor(p => p.DataNascimento.Date)
                .NotEmpty()
                .WithMessage("O campo DataNascimento é obrigatório")
                .Must(DataNascimentoValida)
                .WithMessage("DataNascimento não é válida");

            RuleFor(p => p.Escolaridade)
                .NotNull()
                .WithMessage("O campo Escolaridade é obrigatório")
                .IsInEnum()
                .WithMessage("Escolaridade não é válida");
        }

        public bool DataNascimentoValida(DateTime dataNascimento)
        {
            return dataNascimento.Date.CompareTo(DateTime.Now.Date) < 0;
        }
    }
}
