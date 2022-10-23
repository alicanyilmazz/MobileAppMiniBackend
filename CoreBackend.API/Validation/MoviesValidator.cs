using CoreBackend.API.Models;
using FluentValidation;

namespace CoreBackend.API.Validation
{
    public class MoviesValidator:AbstractValidator<Movie>
    {
        public MoviesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty!");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author can not be empty!");
        }
    }
}
