using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Delete
{
    public class CategoryDeleteCommand : IRequest<string>
    {
        public int Id { get; set; }

        public sealed class CategoryDeleteCommandHandler(ICategoryRepository _categoryRepository, CategoryBusinessRules _businessRules) : IRequestHandler<CategoryDeleteCommand, string>
        {

            public async Task<string> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
            {
                await _businessRules.CategoryIsPresentAsync(request.Id, cancellationToken);

                var category = await _categoryRepository.GetAsync(predicate: x => x.Id == request.Id,
                    cancellationToken: cancellationToken
                );

                await _categoryRepository.DeleteAsync(category, true);

                return "Category deleted successfully";
            }
        }
    }
}
