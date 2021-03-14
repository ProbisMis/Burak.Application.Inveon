using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Burak.Application.Inveon.Business.Validator
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        protected override bool PreValidate(ValidationContext<LoginRequest> context, ValidationResult result)
            => PreValidations.NotNullPreValidation(context, result);

        public LoginRequestValidator()
        {
            RuleFor(r => r.Username).MinimumLength(4).WithMessage("Username lenght should be greater than 4").NotNull();
            RuleFor(r => r.Password).MinimumLength(4).WithMessage("Password lenght should be greater than 4").NotNull();
        }
    }
}
