using Core.Persistence.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Abstracts;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public class CategoryRepository(BaseDbContext dbContext) : EfRepositoryBase<Category, int, BaseDbContext>(dbContext), ICategoryRepository
{
}

