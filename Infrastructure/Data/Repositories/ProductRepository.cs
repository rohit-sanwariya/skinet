﻿using Core;
using Core.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ProductRepository(ApplicationDbContext context) : IProduct
{
    public async Task<ProductBrand> GetProductBrandByIdAsync(int id)
    {
         return await context.ProductBrands.FindAsync(id);
    }

    public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
    {
            return await context.ProductBrands.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<ProductType> GetProductTypeByIdAsync(int id)
    {
         return await context.ProductTypes.FindAsync(id);
    }

    public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
    {
        return await context.ProductTypes.ToListAsync();
    }
}
