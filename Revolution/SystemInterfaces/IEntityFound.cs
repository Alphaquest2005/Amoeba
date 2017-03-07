namespace SystemInterfaces
{
    public interface IEntityFound<out TEntity> : IProcessSystemMessage where TEntity : IEntityId
    {
        TEntity Entity { get; }
    }
}
