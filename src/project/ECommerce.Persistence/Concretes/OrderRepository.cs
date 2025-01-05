using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class OrderRepository:EfRepositoryBase<Order,Guid,BaseDbContext>, IOrderRepository
{
    public OrderRepository(BaseDbContext dbContext) : base(dbContext)
    {
    }
}