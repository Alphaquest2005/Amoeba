namespace SystemInterfaces
{
    
    
    public interface IGetEntityById<out TEntity>:IProcessSystemMessage, IEntityRequest<TEntity> where TEntity:IEntity
    {
       // void Create(int entityId);
        int EntityId { get; }
    }
}