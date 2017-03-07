using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IEntitySetLoaded<TEntity>:IProcessSystemMessage where TEntity : IEntity
    {
        IList<TEntity> Entities { get; }
    }
}
