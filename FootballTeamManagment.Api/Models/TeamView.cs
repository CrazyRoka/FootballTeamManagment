using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManagment.Api.Models
{
    public class TeamView
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Name { get; set; }

        [BindNever]
        public ICollection<FootballPlayerView> FootballPlayers { get; set; }
    }
}
