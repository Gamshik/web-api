using Entites;
using FluentValidation;

namespace cinemaBLL.Validations
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name is required!")
                .Matches("^[a-zA-Z]+$").WithMessage("Is not valid name!");

            RuleFor(a => a.BirthDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Birth date is required!")
                .Must(ValidationHelper.ValidDate).WithMessage("Is not valid date!");
        }
    }
}
