using ECommerce.Application.Features.Categories.Constants;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.Create
{
    internal class CategoryAddValidator : AbstractValidator<CategoryAddCommand>
    {
        public CategoryAddValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(5).WithMessage(CategoryMessages.CategoryNameMustBeMinimumThreeLengthMessage);
        }
    }
}
