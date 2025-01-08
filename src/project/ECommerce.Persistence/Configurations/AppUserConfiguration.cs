using Core.Security.Hashing;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Persistence.Configurations;

internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.ToTable("AppUsers").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.FirstName).HasColumnName("FirstName").IsRequired();
        builder.Property(c => c.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(c => c.Email).HasColumnName("Email").IsRequired();
        builder.Property(c => c.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(c => c.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();

        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(u => u.UserOperationClaims)
            .WithOne()
            .HasForeignKey(u => u.UserId);

        builder.HasData(getData());
    }

    private HashSet<AppUser> getData()
    {
        HashSet<AppUser> users = new HashSet<AppUser>();
        HashingHelper.CreatePasswordHash(
            password: "Password123",
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt

            );
        AppUser adminUser = new()
        {
            Id = 1,
            FirstName = "Kadir Şehmus Arslan",
            LastName = "En iyi Developer",
            Email = "gayet_yeterli_bir_tanıtım@gmail.com",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true,
            CreatedDate = DateTime.UtcNow,
        };
        users.Add(adminUser);
        return users;
    }

}

