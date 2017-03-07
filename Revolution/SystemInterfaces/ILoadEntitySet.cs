namespace SystemInterfaces
{
    
    public interface ILoadEntitySet<out TEntity> : IProcessSystemMessage, IEntityRequest<TEntity> where TEntity:IEntity
    {
    }
}
