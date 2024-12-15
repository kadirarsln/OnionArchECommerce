using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using ECommerce.Persistence.Abstracts;
using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

public sealed class GetListByPaginateCategoryQuery : IRequest<Paginate<GetListByPaginateCategoryResponseDto>>
{
    public PageRequest? PageRequest { get; set; }

    public sealed class GetListByPaginateCategoryHandler(IMapper _mapper, ICategoryRepository categoryRepository) : IRequestHandler<GetListByPaginateCategoryQuery, Paginate<GetListByPaginateCategoryResponseDto>>
    {
        public async Task<Paginate<GetListByPaginateCategoryResponseDto>> Handle(GetListByPaginateCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await categoryRepository.GetPaginateAsync(
                include: false,
                enableTracking: false,
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
                );

            var response = _mapper.Map<Paginate<GetListByPaginateCategoryResponseDto>>(categories);

            return response;
        }
    }
}

