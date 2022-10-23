using CoreBackend.API.Models;
using FluentValidation;

namespace CoreBackend.API.Validation
{
    public class CategoriesValidator : AbstractValidator<Category>
    {
        public CategoriesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty!");
        }
    }
}
