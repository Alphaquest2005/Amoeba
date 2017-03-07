using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemInterfaces
{
    
    public interface ILoadEntitySetWithFilter<TEntity> : IProcessSystemMessage, IEntityRequest<TEntity> where TEntity : IEntity
    {
        List<Expression<Func<TEntity, bool>>> Filter { get; }
    }
}
