using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemInterfaces
{
    
    public interface ILoadEntitySetWithFilterWithIncludes<TEntity> : IProcessSystemMessage, IEntityRequest<TEntity> where TEntity : IEntity
    {
        List<Expression<Func<TEntity, bool>>> Filter { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
    }
}
