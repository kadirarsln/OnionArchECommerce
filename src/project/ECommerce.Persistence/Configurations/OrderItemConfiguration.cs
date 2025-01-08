using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems").HasKey(oi => oi.Id);
        builder.Property(oi => oi.Id).HasColumnName("Id").IsRequired();
        builder.Property(oi => oi.OrderId).HasColumnName("OrderId").IsRequired();
        builder.Property(oi => oi.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(oi => oi.Count).HasColumnName("Count").IsRequired();

        builder.HasOne(oi =>  oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(oi => oi.Product)
            .WithMany()
            .HasForeignKey(oi => oi.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(oi => !oi.DeletedDate.HasValue);
    }
}

