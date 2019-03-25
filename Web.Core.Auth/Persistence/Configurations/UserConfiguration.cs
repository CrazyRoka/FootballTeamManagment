using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Core.Auth.Models;

namespace Web.Core.Auth.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("PasswordHash");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
