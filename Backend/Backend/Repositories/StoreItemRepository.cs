using System;
using AutoMapper;
using Backend.DTOs;
using Backend.Models;
using Backend.Request;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public interface IStoreItemRepository
    {
        Task AddAsync(StoreItemPostDTO itemPost);
        Task DeleteAsync(int id);
        Task<StoreItemGetDTO> FindByIdAsync(int id);
        Task<IEnumerable<StoreItemGetDTO>> GetAllAsync();
        Task UpdateAsync(StoreItemPutDTO storeItem);
    }

    public class StoreItemRepository : IStoreItemRepository
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;

        public StoreItemRepository(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task AddAsync(StoreItemPostDTO itemPost)
        {
            var item = _mapper.Map<StoreItem>(itemPost);
            await _dbContext.StoreItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<StoreItemGetDTO>> GetAllAsync()
        {
            var items = await _dbContext.StoreItems.ToListAsync();
            return _mapper.Map<List<StoreItemGetDTO>>(items);
        }

        public async Task<StoreItemGetDTO> FindByIdAsync(int id)
        {
            var item = await _dbContext.StoreItems.FindAsync(id);
            return _mapper.Map<StoreItemGetDTO>(item);
        }

        public async Task UpdateAsync(StoreItemPutDTO storeItem)
        {
            var item = _mapper.Map<StoreItem>(storeItem);
            _dbContext.StoreItems.Update(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _dbContext.StoreItems.FindAsync(id);
            _dbContext.StoreItems.Remove(item);
            await _dbContext.SaveChangesAsync();
        }
    }
}