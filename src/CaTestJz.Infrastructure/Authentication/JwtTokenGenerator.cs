using CaTestJz.Application.Common.Interfaces.Authentication;
using CaTestJz.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace CaTestJz.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;
        
        public JwtTokenGenerator(
            IOptions<JwtSettings> jwtOptions) // IOptions: we can mock this in a unit test
        {
            _jwtSettings = jwtOptions.Value;
        }

        public string GenerateToken(User user)
        {
            // We use a symmetric key
            // because we are acting as the token issuer
            // and later we will authenticate the users
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSettings.Secret)), // 16 bytes
                    SecurityAlgorithms.HmacSha256);


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            };

            var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
