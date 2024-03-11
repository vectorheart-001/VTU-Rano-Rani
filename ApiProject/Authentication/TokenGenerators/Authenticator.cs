using ApiProject.Domain.Entities;
using ApiProject.Infrastructure.Repository.RefreshTokenRepository;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ApiProject.Api.Authentication.TokenGenerators
{
    public class Authenticator
    {
        private readonly AccessTokenGenerator _accessTokenGenerator;
        private readonly RefreshTokenGenerator _refreshTokenGenerator;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        public Authenticator(AccessTokenGenerator accessTokenGenerator, RefreshTokenGenerator refreshTokenGenerator, IRefreshTokenRepository refreshTokenRepository)
        {
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthenticatedResponse> Authenticate(User user)
        {
            string accessToken = _accessTokenGenerator.GenerateToken(user);
            string refershToken = _refreshTokenGenerator.GenerateToken(user);
            RefreshToken refreshTokenDTO = new RefreshToken
            {
                Token = refershToken,
                UserId = user.Id,
            };
            await _refreshTokenRepository.Create(refreshTokenDTO);
            return new AuthenticatedResponse
            {
                AccessToken = accessToken,
                RefreshToken = refershToken
            };
        }
    }
}

