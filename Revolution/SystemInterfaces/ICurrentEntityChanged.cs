namespace SystemInterfaces
{
    
    public interface ICurrentEntityChanged<out TEntity>:IProcessSystemMessage
    {
        TEntity Entity { get; }
    }
}
