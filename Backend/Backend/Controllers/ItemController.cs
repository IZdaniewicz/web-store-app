using Backend.Models;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class ItemController : ControllerBase
{
    private readonly IStoreItemRepository _storeItemRepository;

    public ItemController(IStoreItemRepository storeItemRepository)
    {
        _storeItemRepository = storeItemRepository;
    }

    [HttpGet("/items")]
    public IActionResult ListItems()
    {
        IEnumerable<StoreItem> items = _storeItemRepository.GetAll();
        return Ok(items);
    }


    [HttpGet("/items/{id:int}")]
    public IActionResult GetUser(int id)
    {
        StoreItem item = _storeItemRepository.FindById(id);
        if (item is null)
        {
            return StatusCode(StatusCodes.Status404NotFound, "No matching Item found");
        }

        return Ok(item);
    }

    [HttpPost("/items")]
    public IActionResult CreateUser([FromBody] StoreItem item)
    {
        try
        {
            _storeItemRepository.Add(item);
            return Ok("Item created!");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }

    [HttpPut("/items/{id:int}")]
    public IActionResult ModifyUser(int id, [FromBody] StoreItem request)
    {
        try
        {
            StoreItem item = _storeItemRepository.FindById(id);
            item.Name = request.Name;
            item.Price = request.Price;
            item.Tag = request.Tag;
            item.Description = request.Description;
            _storeItemRepository.Update(item);
            return Ok("Item updated!");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status400BadRequest, e.ToString());
        }
    }
}