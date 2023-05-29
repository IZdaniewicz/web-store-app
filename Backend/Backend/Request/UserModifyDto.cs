using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class UserModifyDTO
    {
        [Required]
        public string Password { get; set; }
    }
}
