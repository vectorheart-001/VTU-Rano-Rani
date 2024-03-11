using ApiProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repository.MajorRepository
{
    public class MajorRepository : IMajorRepository
    {
        private readonly ApiAppContext _context;
        public MajorRepository(ApiAppContext context)
        {
            _context = context;
        }
        public async Task<List<Major>> GetAll()
        {
            return await _context.Majors.Where(x => x.Id != "000").ToListAsync();
        }

        public Task<List<Major>> GetByFaculty(string faculty)
        {
            throw new NotImplementedException();
        }

        public async Task<Major> GetById(string id)
        {
            return await _context.Majors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
