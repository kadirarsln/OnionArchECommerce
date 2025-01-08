using AutoMapper;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public sealed class AddCategoryCommand : IRequest<AddedCategoryResponseDto>, ILoginRequest
{
    public string Name { get; set; }

    public sealed class AddCategoryCommandHandler(IMapper _mapper, ICategoryRepository _categoryRepository, CategoryBusinessRules _businessRules) : IRequestHandler<AddCategoryCommand, AddedCategoryResponseDto>
    {
        public async Task<AddedCategoryResponseDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryNameMustBeUniqueAsync(request.Name, cancellationToken);
            //Category category = _mapper.Map<Category>(request);
            //Category categoryAdded = await _categoryRepository.AddAsync(category);
            //AddedCategoryResponseDto response = _mapper.Map<AddedCategoryResponseDto>(categoryAdded);

            var category = _mapper.Map<Category>(request);
            var categoryAdded = await _categoryRepository.AddAsync(category);

            var response = _mapper.Map<AddedCategoryResponseDto>(categoryAdded);

            return response;
        }
    }
}

