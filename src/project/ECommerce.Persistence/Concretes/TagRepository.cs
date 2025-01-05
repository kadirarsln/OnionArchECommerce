using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class TagRepository(BaseDbContext dbContext) : EfRepositoryBase<Tag, Guid, BaseDbContext>(dbContext), ITagRepository
{
}