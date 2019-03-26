namespace FootballTeamManagment.Core.Models
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Team Team { get; set; }
    }
}
