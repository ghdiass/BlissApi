using Bliss.Business.Models;
using Bliss.Business.Validations.Extensions;
using FluentValidation;

namespace Bliss.Business.Validations
{
    public class QuestionValidation : AbstractValidator<QuestionModel>
    {
        public QuestionValidation()
        {
            RuleFor(c => c.Question)
                .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                .Length(5, 200).WithMessage("The field {PropertyName} should be between {MinLength} and {MaxLength} chars");

            RuleFor(c => c.Image_url)
                .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                .Length(5, 300).WithMessage("The field {PropertyName} should be between {MinLength} and {MaxLength} chars")
                .Url().WithMessage("Link '{PropertyValue}' must be a valid URI. eg: https://www.blissapplications.com/");

            RuleFor(c => c.Thumb_url)
                .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                .Length(5, 300).WithMessage("The field {PropertyName} should be between {MinLength} and {MaxLength} chars")
                .Url().WithMessage("Link '{PropertyValue}' must be a valid URI. eg: https://www.blissapplications.com/");

            RuleForEach(x => x.Choices)
                .ChildRules(choice =>
                {
                    choice.RuleFor(x => x.Choice)
                        .NotEmpty().WithMessage("The field {PropertyName} can not be null")
                        .Length(1, 250).WithMessage("The field {PropertyName} should be between {MinLength} and {MaxLength} chars");
                });
        }
    }
}
