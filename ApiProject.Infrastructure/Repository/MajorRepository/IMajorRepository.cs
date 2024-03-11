using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiProject.Domain.Entities;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repository.MajorRepository
{
    public interface IMajorRepository
    {
        public  Task<List<Major>> GetAll();
        public Task<Major> GetById(string id);
        public Task<List<Major>> GetByFaculty(string faculty);
    }
}
