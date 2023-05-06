using System.ComponentModel.DataAnnotations;

namespace WebStoreApp.StoreItem.Model;

public class StoreItemModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    private string? Description { get; set; }
    private float Price { get; set; }
}