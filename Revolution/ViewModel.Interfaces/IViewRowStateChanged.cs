using SystemInterfaces;

namespace ViewModel.Interfaces
{
    
    public interface IViewRowStateChanged : IProcessSystemMessage
    {
        IViewModel ViewModel { get; }
        RowState RowState { get; }
    }

    public interface IViewRowStateChanged<TEntity> : IViewRowStateChanged where TEntity : IEntityId
    {

    }
}
