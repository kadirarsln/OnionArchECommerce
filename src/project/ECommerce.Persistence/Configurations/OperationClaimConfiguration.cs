﻿using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);
        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();

        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);
    }

    private HashSet<OperationClaim> getData()
    {
        HashSet<OperationClaim> operationClaims = new()
            {
                new OperationClaim{

                Id = 1,
                Name = "Admin",
                CreatedDate = DateTime.UtcNow,},

                new  OperationClaim{
                Id = 2,
                Name = "User",
                CreatedDate = DateTime.UtcNow,},

                new  OperationClaim{
                Id = 2,
                Name = "Most Valuable People (MVP)",
                CreatedDate = DateTime.UtcNow,}
            };

        return operationClaims;
    }
}

