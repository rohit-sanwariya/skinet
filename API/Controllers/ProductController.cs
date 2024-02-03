 
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

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        Product?  product = await repo.GetProductByIdAsync(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpGet(nameof(GetProductBrand))]
    public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
    {
        var  ProductBrands = await repo.GetProductBrandsAsync();
        return Ok(ProductBrands);
    }

    [HttpGet($"{nameof(GetProductBrand)}/id")]
    public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
    {
        ProductBrand?  ProductBrand = await repo.GetProductBrandByIdAsync(id);
        return ProductBrand != null ? Ok(ProductBrand) : NotFound();
    }
    [HttpGet(nameof(GetProductType))]
    public async Task<ActionResult<List<ProductType>>> GetProductType()
    {
        var  ProductTypes = await repo.GetProductTypesAsync();
        return Ok(ProductTypes);
    }

    [HttpGet($"{nameof(GetProductType)}/id")]
    public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
    {
        ProductType?  ProductType = await repo.GetProductTypeByIdAsync(id);
        return ProductType != null ? Ok(ProductType) : NotFound();
    }
}
