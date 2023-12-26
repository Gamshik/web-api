using Entites.Models;
using FluentValidation;

namespace cinemaBLL.Validations
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required!")
                .Matches("^[a-zA-z0-9]+([ ][a-zA-z0-9]+)*$").WithMessage("Is not valid title");

            RuleFor(m => m.ReleaseDate)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Release date is required!")
                .Must(ValidationHelper.ValidDate).WithMessage("Is not valid date!");

            RuleFor(m => m.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("AuthorId is required!")
                .GreaterThan(0).WithMessage("AuthorId cannot be less than 0!");
        }
    }
}
