using System.ComponentModel.DataAnnotations;

namespace Backend.Request
{
    public class StoreItemPutDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Tag { get; set; }

        public string? Description { get; set; }
    }
}
