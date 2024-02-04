using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class SpecificationEvaluator<TEntity> where TEntity : SkinetBaseModel
{

    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery,ISpecification<TEntity> spec){
        var query = inputQuery;
        if(spec.Criteria != null){
            query = query.Where(spec.Criteria);
        }
        query = spec.includes.Aggregate(query,
            (curr,include)=>curr.Include(include)
        );
        return query;
    }
}
