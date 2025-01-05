using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class ProductImageRepository(BaseDbContext dbContext) : EfRepositoryBase<ProductImage, int, BaseDbContext>(dbContext), IProductImageRepository
{
}