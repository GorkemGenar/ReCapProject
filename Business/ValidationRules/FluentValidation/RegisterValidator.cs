using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class RegisterValidator:AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(r => r.VerifyPassword).Equal(r => r.Password).WithMessage("Şifreler eşleşmiyor.");
        }
    }
}
