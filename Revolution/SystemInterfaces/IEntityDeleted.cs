namespace SystemInterfaces
{
    
    public interface IEntityDeleted<TEntity>:IProcessSystemMessage where TEntity:IEntity
    {
        int EntityId { get; }
    }

}
