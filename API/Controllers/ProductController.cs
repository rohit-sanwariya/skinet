using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProduct repo) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductAsync()
    {
        var  products = await repo.GetProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        Product?  product = await repo.GetProductByIdAsync(id);
        return product != null ? Ok(product) : NotFound();
    }
}
