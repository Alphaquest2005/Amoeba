using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemInterfaces
{
    
    public interface IEntitySetWithFilterWithIncludesLoaded<T> : IProcessSystemMessage where T : IEntity
    {
        IList<T> Entities { get; }
        IList<Expression<Func<T, object>>> Includes { get; }
    }
}
