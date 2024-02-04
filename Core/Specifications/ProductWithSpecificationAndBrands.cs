using System.Linq.Expressions;
using Core.Models;

namespace Core;

public class ProductWithSpecificationAndBrands : BaseSpecification<Product>
{
   
    public ProductWithSpecificationAndBrands()
    {
        
    }
    public ProductWithSpecificationAndBrands(Expression<Func<Product, bool>> criteria) : base(criteria)
    {

        AddIncludes(x => x.ProductBrand!);
        AddIncludes(x => x.ProductType!);
    }
}
