using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.Core.Auth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
