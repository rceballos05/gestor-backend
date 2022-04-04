using FluentValidation;
using GestorUsuarios.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestorUsuarios.Infraestructure.Validators
{
    public class TareaValidator : AbstractValidator<TareaDto>
    {
        public TareaValidator()
        {
            RuleFor(t => t.IdUsuario)
                .NotNull();
            RuleFor(t => t.NombreTarea)
                .NotNull()
                .Length(1, 100);
            RuleFor(t => t.Estado)
                .NotNull();
        }
    }
}
