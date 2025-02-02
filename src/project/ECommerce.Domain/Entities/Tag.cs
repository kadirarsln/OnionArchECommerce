﻿using Core.Persistence.Repositories;

namespace ECommerce.Domain.Entities;

public sealed class Tag : Entity<Guid>
{
    public string Name { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; }
}