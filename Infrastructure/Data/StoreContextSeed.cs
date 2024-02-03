using System.Text.Json;
using Core;
using Core.Models;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data;


public class StoreContextSeed
{
    public static async Task SeedData(ApplicationDbContext context,ILoggerFactory factory)
    {
        try
        {
            if(!context.ProductBrands.Any()){
                var brandsData = 
                File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands  = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                foreach(var  item in brands!){
                    context.ProductBrands.Add(item);
                }
                await context.SaveChangesAsync();
            }
            if(!context.ProductTypes.Any()){
                var brandsData = 
                File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var brands  = JsonSerializer.Deserialize<List<ProductType>>(brandsData);
                foreach(var  item in brands!){
                    context.ProductTypes.Add(item);
                }
                await context.SaveChangesAsync();
            }
            if(!context.Products.Any()){
                var brandsData = 
                File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var brands  = JsonSerializer.Deserialize<List<Product>>(brandsData);
                foreach(var  item in brands!){
                    context.Products.Add(item);
                }
               
                await context.SaveChangesAsync();
            }
          
        }
        catch (Exception ex)
        {
             
            var logger = factory.CreateLogger<StoreContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}