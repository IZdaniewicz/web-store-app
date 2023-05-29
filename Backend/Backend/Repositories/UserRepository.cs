using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _dbContext;
    private readonly IMapper _mapper;

    public UserRepository(DataContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Add(UserPostDTO userPost)
    {
        var user = _mapper.Map<User>(userPost);
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public IEnumerable<UserGetDTO> GetAll()
    {

        var users = _dbContext.Users
            .Include(c => c.Account)
            .ToList();
        return _mapper.Map<List<UserGetDTO>>(users);
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