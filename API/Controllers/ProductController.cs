 
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core;
using Core.Interfaces;
namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(
    IGenericRepository<Product> productRepo,
    IGenericRepository<ProductBrand> productBrandRepo,
    IGenericRepository<ProductType> productTypeRepo
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProductAsync()
    {
        var spec = new  ProductWithSpecificationAndBrands();
        var  products = await productRepo.ListAsync(spec);
        return Ok(products.OrderBy(p=>p.Id));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var spec = new  ProductWithSpecificationAndBrands((c)=>c.Id == id);
        Product?  product = await productRepo.GetEntityWithSpec(spec);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpGet(nameof(GetProductBrand))]
    public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
    {
        var  ProductBrands = await productBrandRepo.ListAllAsync();
        return Ok(ProductBrands);
    }

    [HttpGet($"{nameof(GetProductBrand)}/id")]
    public async Task<ActionResult<ProductBrand>> GetProductBrandById(int id)
    {
        ProductBrand?  ProductBrand = await productBrandRepo.GetByIdAsync(id);
        return ProductBrand != null ? Ok(ProductBrand) : NotFound();
    }
    [HttpGet(nameof(GetProductType))]
    public async Task<ActionResult<List<ProductType>>> GetProductType()
    {
        var  ProductTypes = await productTypeRepo.ListAllAsync();
        return Ok(ProductTypes);
    }

    [HttpGet($"{nameof(GetProductType)}/id")]
    public async Task<ActionResult<ProductType>> GetProductTypeById(int id)
    {
        ProductType?  ProductType = await productTypeRepo.GetByIdAsync(id);
        return ProductType != null ? Ok(ProductType) : NotFound();
    }
}
