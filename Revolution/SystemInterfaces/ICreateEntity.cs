namespace SystemInterfaces
{
    
    public interface ICreateEntity<out TEntity>:IProcessSystemMessage, IEntityRequest<TEntity> where TEntity : IEntity
    {
        TEntity Entity { get; }
    }
}
