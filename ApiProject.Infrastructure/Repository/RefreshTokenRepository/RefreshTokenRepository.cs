using ApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repository.RefreshTokenRepository
{
    internal class RefreshTokenRepository:IRefreshTokenRepository
    {
        private readonly ApiAppContext _context;
        public RefreshTokenRepository(ApiAppContext context)
        {
            _context = context;
        }
        public async Task Create(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var token = _context.RefreshTokens.Find(id);
            _context.Remove(token);
            _context.SaveChanges();
        }

        public async Task DeleteAll(Guid userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens.Where(t => t.UserId == userId).ToListAsync();
            _context.RefreshTokens.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByToken(string refreshToken)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(u => u.Token == refreshToken);
        }
    }
}

