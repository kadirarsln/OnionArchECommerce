namespace ECommerce.Application.Features.Categories.Queries.GetById;

public sealed class GetByIdCategoryResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}