using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ApiProject.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace ApiProject.Api.Authentication.TokenGenerators
{
    public class RefreshTokenGenerator
    {
        private readonly AuthenticationConfiguration _configuration;

        public RefreshTokenGenerator(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.Id.ToString()),
            };
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.RefreshTokenSecret));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(_configuration.Issuer,
                _configuration.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpepirationMinutes),
                signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
