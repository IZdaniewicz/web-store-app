using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;

    public UserRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(UserAddDTO u)
    {
        User user = new User(u.Username, u.Password, u.Balance);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public User FindById(int id)
    {
        return _dbContext.Users.Find(id);
    }

    public User FindByUsername(string username)
    {
        return _dbContext.Users.Single(user => user.Username == username);
    }

    public void Update(User u)
    {
        _dbContext.Users.Update(u);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var user = _dbContext.Users.Find(id);
        _dbContext.Users.Remove(user);
        _dbContext.SaveChanges();
    }
}