using Backend.Migrations;
using Backend.Models;

namespace Backend.Repositories;

public interface IStoreItemRepository
{
    public void Add(StoreItem u);

    public IEnumerable<StoreItem> GetAll();

    public StoreItem FindById(int id);

    public void Update(StoreItem u);

    public void Delete(StoreItem u);
}