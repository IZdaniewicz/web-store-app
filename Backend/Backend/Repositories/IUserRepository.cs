using Backend.DTOs;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        void Add(UserAddDTO u);
        void Delete(int id);
        User FindById(int id);
        User FindByUsername(string username);
        IEnumerable<User> GetAll();
        void Update(User u);
    }
}