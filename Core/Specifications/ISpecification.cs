﻿using System.Linq.Expressions;

namespace Core;

public interface ISpecification<T>
{

    Expression<Func<T,bool>> Criteria {get;}
    
    List<Expression<Func<T,object>>> includes {get;}
}
