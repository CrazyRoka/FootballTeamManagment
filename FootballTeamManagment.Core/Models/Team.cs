using System.Collections.Generic;

namespace FootballTeamManagment.Core.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FootballPlayer> FootballPlayers { get; set; } = new HashSet<FootballPlayer>();
    }
}
