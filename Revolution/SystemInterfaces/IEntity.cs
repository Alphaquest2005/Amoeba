namespace SystemInterfaces
{
    
    public interface IEntity:IEntityId
    {
        RowState RowState { get; set; }

        dynamic ComputedProperties { get; }
    }
}