using Infrastructure.Data;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductAsync()
    {
        var  products = await context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        Product?  product = await context.Products.FindAsync(id);
        return product != null ? Ok(product) : NotFound();
    }
}
