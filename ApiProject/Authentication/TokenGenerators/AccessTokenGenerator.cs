using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using ApiProject.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SkiaSharp;

namespace ApiProject.Api.Authentication.TokenGenerators
{
    public class AccessTokenGenerator
    {
        private readonly AuthenticationConfiguration _configuration;

        public AccessTokenGenerator(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("id",user.Id.ToString()),
                new Claim("name",user.FirstName + " " + user.SecondName +  " " + user.LastName),
                new Claim("phone",user.Phone),
                new Claim("personalId",user.PeronalId),
                new Claim("request_status",user.Status.ToString()),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("major_id",user.MajorId),

            };
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.AccessTokenSecret));
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
