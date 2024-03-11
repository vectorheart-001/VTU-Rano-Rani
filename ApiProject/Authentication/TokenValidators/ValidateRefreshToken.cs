using System.IdentityModel.Tokens.Jwt;
using System.IdentityModel.Tokens;
using System.Text;
using ApiProject.Api.Authentication.TokenGenerators;
using Microsoft.IdentityModel.Tokens;
namespace ApiProject.Api.Authentication.TokenValidators
{
    public class ValidateRefreshToken
    {
        private readonly AuthenticationConfiguration _configuration;
        public ValidateRefreshToken(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool is_Valid(string refreshToken)
        {
            TokenValidationParameters validationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.RefreshTokenSecret)),
                ValidIssuer = _configuration.Issuer,
                ValidAudience = _configuration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero,
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken secureToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
