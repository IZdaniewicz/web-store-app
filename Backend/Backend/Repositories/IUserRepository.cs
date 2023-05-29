using Backend.DTOs;
using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserRepository
    {
        void Add(UserPostDTO userPost);
        void Delete(int id);
        User FindById(int id);
        User FindByUsername(string username);
        IEnumerable<UserGetDTO> GetAll();
        void Update(User u);
    }
}