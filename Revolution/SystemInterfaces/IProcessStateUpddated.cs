using System;

namespace SystemInterfaces
{
    
    public interface IProcessStateUpddated : IProcessSystemMessage
    {
        Type EntityType { get; }
        IProcessStateMessage<IEntityId> StateMessage { get; }
    }
}
