using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class User
{
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Username { get; set; }

    [Column("password")]
    public string Password { get; set; }

    public virtual Account Account { get; set; } = null!;

    public User()
    {
        Account = new Account();
    }
    public User(string username, string password, decimal balance)
    {
        Username = username;
        Password = password;
        Account = new Account { Balance = balance, UserId = Id };
    }
}