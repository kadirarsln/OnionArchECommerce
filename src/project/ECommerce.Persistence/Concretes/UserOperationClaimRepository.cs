using Core.Persistence.Repositories;
using Core.Security.Entities;
using ECommerce.Application.Services.Repositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class UserOperationClaimRepository(BaseDbContext dbContext)
    : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>(dbContext), IUserOperationClaimRepository;