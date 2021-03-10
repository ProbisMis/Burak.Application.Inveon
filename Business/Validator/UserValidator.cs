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
    public class UserValidator : AbstractValidator<UserRequest>
    {
        protected override bool PreValidate(ValidationContext<UserRequest> context, ValidationResult result)
           => PreValidations.NotNullPreValidation(context, result);

        public UserValidator()
        {
            RuleFor(r => r.Username).NotNull();
        }
    }
}
