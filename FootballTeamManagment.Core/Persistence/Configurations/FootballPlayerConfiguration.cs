using FootballTeamManagment.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootballTeamManagment.Core.Persistence.Configurations
{
    public class FootballPlayerConfiguration : IEntityTypeConfiguration<FootballPlayer>
    {
        public void Configure(EntityTypeBuilder<FootballPlayer> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.HasOne(d => d.Team)
                .WithMany(p => p.FootballPlayers)
                .HasForeignKey(d => d.TeamId);
        }
    }
}
