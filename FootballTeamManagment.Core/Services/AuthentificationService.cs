using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using FootballTeamManagment.Core.Security;

namespace FootballTeamManagment.Core.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenOptions _tokenOptions;
        private readonly IPasswordHasher _passwordHasher;
        public AuthentificationService(
            IUnitOfWork unitOfWork,
            SigningConfigurations signingConfigurations,
            TokenOptions tokenOptions,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _signingConfigurations = signingConfigurations;
            _tokenOptions = tokenOptions;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Authentificate(string email, string password)
        {
            User user = await _unitOfWork.UserRepository.FindAsync(u => u.Email == email);
            if (user == null || !_passwordHasher.PasswordMatches(password, user.Password))
            {
                return null;
            }

            var token = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: GetClaims(user),
                expires: DateTime.UtcNow.AddSeconds(_tokenOptions.AccessTokenExpiration),
                notBefore: DateTime.UtcNow,
                signingCredentials: _signingConfigurations.SigningCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email)
            };

            foreach(var userRole in user.UserRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.Role.Name));
            }

            return claims;
        }
    }
}
