using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Account
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
