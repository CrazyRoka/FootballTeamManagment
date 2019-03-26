using FootballTeamManagment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeamManagment.Core.Persistence.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(120);
        }
    }
}
