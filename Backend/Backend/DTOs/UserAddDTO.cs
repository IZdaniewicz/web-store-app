using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserAddDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public decimal Balance { get; set; }
    }
}
