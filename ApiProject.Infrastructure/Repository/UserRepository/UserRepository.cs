
using ApiProject.Domain.Entities;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProject.Domain.DTOs.UserDTO;

namespace ApiProject.Infrastructure.Repository.UserRepository
{
    public class UserRepository:IUserRepository
    {
        protected readonly ApiAppContext _context;
        public UserRepository(ApiAppContext context)
        {
            _context = context;
        }

        public async Task ConfirmPayment(Guid Id)
        {
            var editUser = await _context.Users.FindAsync(Id);
            editUser.Status = Domain.Enums.RequestStatus.Status.Платена;
            _context.Users.Update(editUser);
            await _context.SaveChangesAsync();
            
        }

        public async Task Create(UserRegisterRequest request)
        {
            User user = new User()
            {
                Email = request.Email,
                PeronalId = request.PersonalId,
                FirstName = request.FirstName,
                SecondName = request.SecondName,
                LastName = request.LastName,
                Phone = request.Phone,
                MajorId = "000",
                Status = Domain.Enums.RequestStatus.Status.None
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public Task<User> GetById(Guid id)
        {
            return  _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User> GetByPersonalId(string id)
        {
            return  _context.Users.FirstOrDefaultAsync(x => x.PeronalId == id);
        }

        public Task<Dictionary<string, string>> GetMajor(string userid, string majorId)
        {
            throw new NotImplementedException();
        }

        public async Task SetMajor(Guid userId, string majorId)
        {
            var editUser = await _context.Users.FindAsync(userId);
            editUser.MajorId = majorId;
            editUser.Status = Domain.Enums.RequestStatus.Status.Незаплатена;
            _context.Users.Update(editUser);
            await _context.SaveChangesAsync();
        }
    }
}

