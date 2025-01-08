using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;
public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable("ProductTags").HasKey(pt => pt.Id);
        builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
        builder.Property(pt => pt.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pt => pt.TagId).HasColumnName("TagId").IsRequired();

        builder.HasOne(pt => pt.Product)
            .WithMany(p => p.ProductTags)
            .HasForeignKey(pt => pt.ProductId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(pt => pt.Tag)
            .WithMany(t => t.ProductTags)
            .HasForeignKey(pt => pt.TagId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(pt => !pt.DeletedDate.HasValue);
    }

}
