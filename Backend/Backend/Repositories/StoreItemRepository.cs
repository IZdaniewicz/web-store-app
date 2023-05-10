using Backend.Models;

namespace Backend.Repositories;

public class StoreItemRepository : IStoreItemRepository
{
    private readonly DataContext _dbContext;
    
    public StoreItemRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(StoreItem storeItem)
    {
        _dbContext.StoreItems.Add(storeItem);
        _dbContext.SaveChanges();
    }

    public IEnumerable<StoreItem> GetAll()
    {
        return _dbContext.StoreItems.ToList();   
        
    }
    
    public StoreItem FindById(int id)
    {
        return _dbContext.StoreItems.Find(id);
    }

    public void Update(StoreItem storeItem)
    {
        _dbContext.StoreItems.Update(storeItem);
        _dbContext.SaveChanges();
    }

    public void Delete(StoreItem storeItem)
    {
        _dbContext.StoreItems.Remove(storeItem);
        _dbContext.SaveChanges();
    }
}