using Core.Models;

namespace Core;

public interface IProduct
{
    Task<Product> GetProductByIdAsync(int id);
    Task<IReadOnlyList<Product>> GetProductsAsync();
    Task<ProductBrand> GetProductBrandByIdAsync(int id);
    Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
    Task<ProductType> GetProductTypeByIdAsync(int id);
    Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}
