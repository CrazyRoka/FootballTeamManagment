using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Core.Auth.Models;
using Web.Core.Auth.Persistence;
using Web.Core.Auth.Security;

namespace Web.Core.Auth.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenOptions _tokenOptions;
        public AuthentificationService(IUnitOfWork unitOfWork, SigningConfigurations signingConfigurations, TokenOptions tokenOptions)
        {
            _unitOfWork = unitOfWork;
            _signingConfigurations = signingConfigurations;
            _tokenOptions = tokenOptions;
        }

        public async Task<string> Authentificate(string email, string password)
        {
            //User user = await _unitOfWork.UserRepository.FindAsync(u => u.Email == email && u.Password == password);
            User user = new User { FirstName = "Rostyslav", Id = 3, LastName = "Toch", Email = "RokaRostuk@gmail.com" };
            if(user == null)
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
