using FluentValidation;
using GestorUsuarios.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nombre)
                .NotNull()
                .Length(1, 70);
            RuleFor(u => u.Apellido)
                .NotNull()
                .Length(1, 70);
            RuleFor(u => u.Rut)
                .NotNull()
                .Length(8, 9);
            RuleFor(u => u.Cargo)
                .NotNull()
                .Length(1, 100);
            RuleFor(u => u.Correo)
                .NotNull()
                .Length(15, 150);
            RuleFor(u => u.Rol)
                .NotNull();
            RuleFor(u => u.IdLogin)
                .NotNull();
               
        }
    }
}
