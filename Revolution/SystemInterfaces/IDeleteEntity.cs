namespace SystemInterfaces
{
    
    public interface IDeleteEntity<out TEntity> : IProcessSystemMessage, IEntityRequest<TEntity> where TEntity:IEntity
    {
        int EntityId { get; }
    }
}
