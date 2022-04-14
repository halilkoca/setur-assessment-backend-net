using Contact.API.Model;
using FluentValidation;

namespace Contact.API.FluentValidation
{
    public class ContactModelValidator : AbstractValidator<ContactModel>
    {
        public ContactModelValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{Name} must not exceed 3 characters.")
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{LastName} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{LastName} must not exceed 3 characters.")
                .MaximumLength(50).WithMessage("{LastName} must not exceed 50 characters.");

            RuleFor(p => p.Firm)
                .NotEmpty().WithMessage("{Firm} is required.")
                .NotNull()
                .MinimumLength(3).WithMessage("{Firm} must not exceed 3 characters.")
                .MaximumLength(50).WithMessage("{Firm} must not exceed 50 characters.");

        }
    }
}
