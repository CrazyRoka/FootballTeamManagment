using System.ComponentModel.DataAnnotations;

namespace FootballTeamManagment.Api.Models
{
    public class ResetPasswordRequest
    {
        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
}
