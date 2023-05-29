using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserGetDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
