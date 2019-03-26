using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FootballTeamManagment.Api.Models
{
    public class TeamInput
    {
        [Required]
        [StringLength(120, MinimumLength = 1)]
        public string Name { get; set; }
    }
}
