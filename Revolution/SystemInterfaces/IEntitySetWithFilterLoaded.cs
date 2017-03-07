using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IEntitySetWithFilterLoaded<TEntity> : IProcessSystemMessage where TEntity : IEntity
    {
        IList<TEntity> Entities { get; }
    }
}
