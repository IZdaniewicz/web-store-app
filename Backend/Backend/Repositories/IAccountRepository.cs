using Backend.Models;

namespace Backend.Repositories
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Delete(int id);
        Account FindById(int id);
        IEnumerable<Account> GetAll();
        void Update(Account account);
    }
}