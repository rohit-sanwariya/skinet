using System.Linq.Expressions;

namespace Core;

public class BaseSpecification<T> : ISpecification<T>
{
    public BaseSpecification()
    {
        
    }
    public BaseSpecification(Expression<Func<T, bool>> criteria)
   {
    Criteria = criteria;
   }
    public Expression<Func<T, bool>> Criteria {get;}

    public List<Expression<Func<T, object>>> includes {get;} = [];

    protected void AddIncludes(Expression<Func<T,object>> include){ 
        includes.Add(include);
    }
}
