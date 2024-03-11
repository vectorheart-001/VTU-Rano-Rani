using ApiProject.Api.Authentication.TokenGenerators;
using ApiProject.Api.Authentication.TokenValidators;

namespace ApiProject.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<RefreshTokenGenerator>();
            services.AddTransient<Authenticator>();
            services.AddSingleton<ValidateRefreshToken>();
            services.AddTransient<AccessTokenGenerator>();
            services.AddSingleton<ValidateRefreshToken>();
            return services;
        }
    }
}
