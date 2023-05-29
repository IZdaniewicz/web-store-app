using System.ComponentModel.DataAnnotations;
namespace Backend.Request
{
    public class AccountModifyDto
    {
        [Required]
        public decimal Balance { get; set; }
    }
}
