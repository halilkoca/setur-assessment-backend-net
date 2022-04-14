using Contact.API.Model;
using FluentValidation;

namespace Contact.API.FluentValidation
{
    public class ContactInformationValidator : AbstractValidator<ContactInformationModel>
    {
        public ContactInformationValidator()
        {
            RuleFor(p => p.Value)
                .NotEmpty().WithMessage("{Value} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{Value} must not exceed 3 characters.")
                .MaximumLength(50).WithMessage("{Value} must not exceed 50 characters.");
        }
    }
}
