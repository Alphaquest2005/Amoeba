using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IEntityWithChangesFound<TEntity>:IProcessSystemMessage where TEntity : IEntity
    {
        TEntity Entity { get; set; }
        Dictionary<string, object> Changes { get; }
    }
}
