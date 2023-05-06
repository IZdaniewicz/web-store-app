using Microsoft.AspNetCore.Mvc;

namespace WebStoreApp.Controllers;

[ApiController]
[Route("store-item")]
public class StoreItemController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult GetStoreItem()
    {
        return Ok("Success");
    }
}