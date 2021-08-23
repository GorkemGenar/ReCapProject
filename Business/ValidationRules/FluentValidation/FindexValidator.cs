using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class FindexValidator:AbstractValidator<Findex>
    {
        public FindexValidator()
        {
            RuleFor(f => f.FindexRate).GreaterThanOrEqualTo(0);
            RuleFor(f => f.FindexRate).LessThanOrEqualTo(1900);
        }
    }
}
