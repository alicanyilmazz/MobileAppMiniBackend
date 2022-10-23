using CoreBackend.API.Models;
using FluentValidation;

namespace CoreBackend.API.Validation
{
    public class ActressValidator : AbstractValidator<Actress>
    {
        public ActressValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty!");
        }
    }
}
