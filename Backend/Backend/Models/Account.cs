using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Account
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
    }
}
