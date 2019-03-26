using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Auth.Models;

namespace Web.Core.Auth.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user, ApplicationRole[] roles);
    }
}
