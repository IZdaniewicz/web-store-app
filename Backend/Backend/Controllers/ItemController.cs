using System;
using Backend.Models;
using Backend.Repositories;
using Backend.Request;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class ItemController : ControllerBase
    {
        private readonly IStoreItemRepository _storeItemRepository;

        public ItemController(IStoreItemRepository storeItemRepository)
        {
            _storeItemRepository = storeItemRepository;
        }

        [HttpGet("/items")]
        public async Task<IActionResult> GetItemsAll()
        {
            IEnumerable<StoreItemGetDTO> items = await _storeItemRepository.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("/items/{id:int}")]
        public async Task<IActionResult> GetItemById(int id)
        {
            StoreItemGetDTO item = await _storeItemRepository.FindByIdAsync(id);
            if (item is null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "No matching Item found");
            }

            return Ok(item);
        }

        [HttpPost("/items")]
        public async Task<IActionResult> CreateItem([FromBody] StoreItemPostDTO item)
        {
            try
            {
                await _storeItemRepository.AddAsync(item);
                return Ok("Item created!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpPut("/items/{id:int}")]
        public async Task<IActionResult> ModifyItem(int id, [FromBody] StoreItemPutDTO request)
        {
            try
            {
                await _storeItemRepository.UpdateAsync(request);
                return Ok("Item modified!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }

        [HttpDelete("/items/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _storeItemRepository.DeleteAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
            }
        }
    }
}