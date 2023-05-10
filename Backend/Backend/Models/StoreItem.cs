using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class StoreItem
{
    [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; }
    [Column("price")] public float Price { get; set; }
    [Column("tag")] public string Tag { get; set; }
    [Column("description")] public string? Description { get; set; }
}