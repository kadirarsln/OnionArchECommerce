using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class OrderItemRepository : EfRepositoryBase<OrderItem,Guid,BaseDbContext>, IOrderItemRepository
{
    public OrderItemRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}