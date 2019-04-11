using FootballTeamManagment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeamManagment.Core.Persistence.Configurations
{
    public class SnowboardConfiguration : IEntityTypeConfiguration<Snowboard>
    {
        public void Configure(EntityTypeBuilder<Snowboard> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(e => e.Amount)
                .IsRequired();

            builder.Property(e => e.Image)
                .IsRequired();

            builder.Property(d => d.Price)
                .IsRequired();
        }
    }
}
