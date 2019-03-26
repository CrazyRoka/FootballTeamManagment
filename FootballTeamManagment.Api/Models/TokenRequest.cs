using System.ComponentModel.DataAnnotations;

namespace FootballTeamManagment.Api.Models
{
    public class TokenRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
