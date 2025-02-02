﻿using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Concretes;

public sealed class CategoryRepository(BaseDbContext dbContext) : EfRepositoryBase<Category, int, BaseDbContext>(dbContext), ICategoryRepository
{
}