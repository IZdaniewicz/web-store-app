using Microsoft.EntityFrameworkCore;
using WebStoreApp.Data;
using WebStoreApp.StoreItem.Model;

namespace WebStoreApp.StoreItem.Repository;

public class StoreItemRepository
{
    private readonly AppDbContext _dbContext;

    public StoreItemRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddItem(StoreItemModel item)
    {
        _dbContext.StoreItems.Add(item);
        _dbContext.SaveChanges();
    }

    public void Update(StoreItemModel item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var item = _dbContext.StoreItems.Find(id);
        if (item != null)
        {
            _dbContext.StoreItems.Remove(item);
            _dbContext.SaveChanges();
        }
    }

    public StoreItemModel GetById(int id)
    {
        return _dbContext.StoreItems.Find(id);
    }
}