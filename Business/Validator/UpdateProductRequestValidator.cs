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
            RuleFor(r => r.Description).NotNull();
            RuleFor(r => r.ProductName).NotNull();
            RuleFor(r => r.Price).GreaterThanOrEqualTo(0).NotNull();
            RuleFor(r => r.Quantity).GreaterThanOrEqualTo(0).NotNull();
        }
    }
}
