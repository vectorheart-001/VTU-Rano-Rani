using ApiProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repository.RefreshTokenRepository
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string refreshToken);
        Task Create(RefreshToken refreshToken);
        Task Delete(Guid id);
        Task DeleteAll(Guid userId);
    }
}
