namespace FootballTeamManagment.Core.Security
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);
        bool PasswordMatches(string password, string hashedPassword);
    }
}
