using Burak.Application.Inveon.Models.Request;
using Burak.Application.Inveon.Utilities.ValidationHelper;
using FluentValidation;
using FluentValidation.Results;

namespace Burak.Application.Inveon.Business.Validator
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        protected override bool PreValidate(ValidationContext<UpdateProductRequest> context, ValidationResult result)
            => PreValidations.NotNullPreValidation(context, result);

        public UpdateProductRequestValidator()
        {
            RuleFor(r => r.SKU).NotNull();
        }
    }
}
