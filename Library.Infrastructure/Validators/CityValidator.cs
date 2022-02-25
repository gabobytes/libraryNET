using FluentValidation;
using Library.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Validators
{
    public class CityValidator : AbstractValidator <CityDto>
    {
        public CityValidator()
        {
            RuleFor(city => city.NameCity)
                .NotNull()
                .Length(3, 255);
        }
    }
}
