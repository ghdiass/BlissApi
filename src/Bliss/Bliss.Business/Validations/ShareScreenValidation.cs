using Bliss.Business.Dtos;
using Bliss.Business.Validations.Extensions;
using FluentValidation;

namespace Bliss.Business.Validations
{
    public class ShareScreenValidation : AbstractValidator<ShareScreenDto>
    {
        public ShareScreenValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                .EmailAddress().WithMessage("E-mail not valid");

            RuleFor(c => c.Url)
                .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                .Length(5, 300).WithMessage("The field {PropertyName} should be between {MinLength} and {MaxLength} chars")
                .Url().WithMessage("Link '{PropertyValue}' must be a valid URI. eg: https://www.blissapplications.com/");
        }
    }
}
