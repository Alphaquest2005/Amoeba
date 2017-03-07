using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IGetEntityWithChanges<out TEntity> : IProcessSystemMessage, IEntityRequest<TEntity> where TEntity:IEntity
    {
        Dictionary<string, object> Changes { get; }
    }
}
