 using System.ComponentModel.DataAnnotations;

namespace FootballTeamManagment.Api.Models
{
    public class UserView
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]+$")]
        public string LastName { get; set; }
    }
}
