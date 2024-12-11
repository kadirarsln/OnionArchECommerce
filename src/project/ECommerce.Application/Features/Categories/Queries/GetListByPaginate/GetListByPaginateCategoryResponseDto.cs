using MediatR;

namespace ECommerce.Application.Features.Categories.Queries.GetListByPaginate;

public sealed class GetListByPaginateCategoryResponseDto 
{
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}

