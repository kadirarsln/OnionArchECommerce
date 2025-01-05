using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class ProductTag : Entity<Guid>
{
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid TagId { get; set; }
    public Tag Tag { get; set; }
} 