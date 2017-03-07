using System;

namespace SystemInterfaces
{
    
    public interface IEntityViewRequest<out TEntityView>: IEntityViewRequest where TEntityView: IEntityView
    {

    }


    
    public interface IEntityViewRequest:IProcessSystemMessage
    {
        Type ViewType { get; }
    }
}