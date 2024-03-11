using Microsoft.Extensions.DependencyInjection;
using ApiProject.Infrastructure.Repository;

using Microsoft.EntityFrameworkCore;

using ApiProject.Infrastructure.Repository.RefreshTokenRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiProject.Infrastructure.Repository.UserRepository;
using ApiProject.Infrastructure.Repository.MajorRepository;

namespace ApiProject.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ApiAppContext>();
            services.AddMemoryCache();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMajorRepository, MajorRepository>();
            return services;
        }
    }
}