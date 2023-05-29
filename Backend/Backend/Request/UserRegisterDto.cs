using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserRegisterDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        [Required]
        public int Balance { get; set; }

    }
}
