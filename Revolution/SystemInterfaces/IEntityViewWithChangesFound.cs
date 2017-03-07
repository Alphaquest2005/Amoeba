using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IEntityViewWithChangesFound<TView> : IProcessSystemMessage
    {
        TView Entity { get; set; }
        Dictionary<string, object> Changes { get; }
    }

    
    public interface IEntityViewWithChangesUpdated<TView> : IProcessSystemMessage
    {
        TView Entity { get; set; }
        Dictionary<string, object> Changes { get; }
    }
}
