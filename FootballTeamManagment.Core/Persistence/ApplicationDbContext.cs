using Microsoft.EntityFrameworkCore;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence.Configurations;

namespace FootballTeamManagment.Core.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<FootballPlayer> FootballPlayers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new FootballPlayerConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
