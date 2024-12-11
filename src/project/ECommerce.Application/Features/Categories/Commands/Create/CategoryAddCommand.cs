using AutoMapper;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public sealed class CategoryAddCommand : IRequest<CategoryAddedResponseDto>
{
    public string Name { get; set; }

    public class CategoryAddCommandHandler(IMapper _mapper, ICategoryRepository _categoryRepository ,CategoryBusinessRules _businessRules) : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {
        public async Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryNameMustBeUniqueAsync(request.Name, cancellationToken);

            Category category = _mapper.Map<Category>(request);
            Category categoryAdded = await _categoryRepository.AddAsync(category);

            CategoryAddedResponseDto response = _mapper.Map<CategoryAddedResponseDto>(categoryAdded);

            return response;
        }
    }
}

