using System.Security.Principal;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IAccountRepository
    {
        Task AddAsync(Account account);
        Task DeleteAsync(int id);
        Task<Account> FindByIdAsync(int id);
        Task<IEnumerable<Account>> GetAllAsync();
        Task UpdateAsync(Account account);
    }

    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dbContext;
        public AccountRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        public async Task<Account> FindByIdAsync(int id)
        {
            return await _dbContext.Accounts.FindAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            _dbContext.Accounts.Add(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _dbContext.Accounts.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var acc = await _dbContext.Accounts.FindAsync(id);
            _dbContext.Accounts.Remove(acc);
            await _dbContext.SaveChangesAsync();
        }
    }
}
