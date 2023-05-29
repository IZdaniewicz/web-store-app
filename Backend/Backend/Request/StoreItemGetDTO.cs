using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Request
{
    public class StoreItemGetDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Tag { get; set; }

        public string? Description { get; set; }
    }
}
