using Microsoft.EntityFrameworkCore;
using WebStoreApp.StoreItem.Model;

namespace WebStoreApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<StoreItemModel> StoreItems { get; set; }
}