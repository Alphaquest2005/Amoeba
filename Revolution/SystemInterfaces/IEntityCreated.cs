namespace SystemInterfaces
{
    
    public interface IEntityCreated<out TEntity>:IProcessSystemMessage where TEntity : IEntity
    {
        TEntity Entity { get; }
    }
}
