using FluentValidation;
using GestorUsuarios.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(l => l.Usuario)
                .NotNull()
                .Length(5, 50);
            RuleFor(l => l.Contraseña)
                .NotNull()
                .Length(1, 10);
        }
    }
}
