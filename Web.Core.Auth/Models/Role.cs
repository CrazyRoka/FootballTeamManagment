using System.Collections.Generic;

namespace Web.Core.Auth.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
