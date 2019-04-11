﻿using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public interface IAuthentificationService
    {
        Task<string> Authentification(string email, string password);
    }
}
