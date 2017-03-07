namespace SystemInterfaces
{
    public interface IEntityUpdated<out TEntity> : IProcessSystemMessage where TEntity : IEntityId
    {
        TEntity Entity { get; }
    }
}
