using Application.Extentions.Validation;
using FluentValidation;

namespace Application.Features.SampleModel.Commands.CreateSampleModel;

public class CreateSampleModelValidator : AbstractValidator<CreateSampleModelCommand>
{
    public CreateSampleModelValidator()
    {
        RuleFor(x => x.FirstName).Must(ValidationHelper.IsValidString).WithMessage(Resources.Validations.RequiredProperty);
        RuleFor(x => x.FirstName).MinimumLength(2).WithMessage(Resources.Validations.StringLength);
        RuleFor(x => x.FirstName).Matches(Resources.RegexPatterns.Name).WithMessage(Resources.Validations.Name);
        RuleFor(x => x.LastName).Must(ValidationHelper.IsValidString).WithMessage(Resources.Validations.RequiredProperty);
        RuleFor(x => x.LastName).MinimumLength(2).WithMessage(Resources.Validations.StringLength);
        RuleFor(x => x.LastName).Matches(Resources.RegexPatterns.Name).WithMessage(Resources.Validations.Name);
        RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage(Resources.Validations.AgeOver18);
        RuleFor(x => x.Address).MinimumLength(10).WithMessage(Resources.Validations.StringLength);
        RuleFor(x => x.Address).Matches(Resources.RegexPatterns.Address).WithMessage(Resources.Validations.Address);

    }
}
