using System.Security.Principal;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _dbContext;

        public AccountRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }
        public Account FindById(int id)
        {
            return _dbContext.Accounts.Find(id);
        }
        public void Add(Account account)
        {
            _dbContext.Accounts.Add(account);
            _dbContext.SaveChanges();
        }
        public void Update(Account account)
        {
            _dbContext.Accounts.Update(account);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var acc = _dbContext.Accounts.Find(id);
            _dbContext.Accounts.Remove(acc);
            _dbContext.SaveChanges();
        }
    }
}
