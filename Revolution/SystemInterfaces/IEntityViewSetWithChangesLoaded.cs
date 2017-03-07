using System.Collections.Generic;

namespace SystemInterfaces
{
    
    public interface IEntityViewSetWithChangesLoaded<TView> : IProcessSystemMessage where TView : IEntityView
    {
        List<TView> EntitySet { get; }
        Dictionary<string, object> Changes { get; }
    }

}
