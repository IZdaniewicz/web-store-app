using System;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(UserRegisterDTO userPost);
        Task DeleteAsync(int id);
        Task<User> FindByIdAsync(int id);
        Task<User> FindByUsernameAsync(string username);
        Task<IEnumerable<User>> GetAllAsync();
        Task UpdateAsync(User u);
    }

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(UserRegisterDTO userPost)
        {
            var user = _mapper.Map<User>(userPost);
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users
                .Include(c => c.Account)
                .ToListAsync();
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(u => u.Account)
                .FirstOrDefaultAsync(u => u.Id == id);

        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(user => user.Username == username);
        }

        public async Task UpdateAsync(User u)
        {
            _dbContext.Users.Update(u);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}