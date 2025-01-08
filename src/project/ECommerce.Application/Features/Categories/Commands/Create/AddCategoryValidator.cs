using ECommerce.Application.Features.Categories.Constants;
using FluentValidation;

namespace ECommerce.Application.Features.Categories.Commands.Create
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(3).WithMessage(CategoryMessages.CategoryNameMustBeMinimumThreeLengthMessage);
        }
    }
}
