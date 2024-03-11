using ApiProject.Domain.DTOs.UserDTO;
using ApiProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProject.Infrastructure.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);
        
        Task Create(UserRegisterRequest request);
        Task<User> GetByPersonalId(string id);
        Task SetMajor(Guid userId, string majorId);
        Task<Dictionary<string,string>> GetMajor(string userid, string majorId);

        Task<User> GetById(Guid id);
        Task ConfirmPayment(Guid Id);

    }
}
