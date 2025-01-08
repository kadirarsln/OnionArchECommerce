using AutoMapper;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetById;

public sealed class GetByIdCategoryQuery : IRequest<GetByIdCategoryResponseDto>
{
    public int Id { get; set; }
    public sealed class GetByCategoryIdHandler(IMapper _mapper, ICategoryRepository _categoryRepository) : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryResponseDto>
    {
        public async Task<GetByIdCategoryResponseDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {

            var category = await _categoryRepository.GetAsync(predicate: x => x.Id == request.Id,
                    enableTracking: false,
                    include: false,
                    cancellationToken: cancellationToken
                    );
            var response = _mapper.Map<GetByIdCategoryResponseDto>(category);
            return response;
        }
    }
}

