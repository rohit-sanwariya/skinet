using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    [HttpGet]
    public IActionResult GetProduct()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(int id)
    {
        return Ok(id);
    }
}
