using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class ProductImage : Entity<int>
{
    public string Url { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
}  