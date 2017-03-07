using System.Collections.Generic;
using System.ComponentModel.Composition;
using SystemInterfaces;
using CommonMessages;

namespace EventMessages.Events
{
    [Export(typeof(IEntityViewSetWithChangesLoaded<>))]
    public class EntityViewSetWithChangesLoaded<TView>:ProcessSystemMessage, IEntityViewSetWithChangesLoaded<TView> where TView: IEntityView
    {
        public EntityViewSetWithChangesLoaded() { }
        public List<TView> EntitySet { get; }
        public Dictionary<string, object> Changes { get; }

        public EntityViewSetWithChangesLoaded(List<TView> entitySet, Dictionary<string, object> changes, IStateEventInfo stateEventInfo, ISystemProcess process, ISystemSource source):base(stateEventInfo,process, source)
        {
            EntitySet = entitySet;
            Changes = changes;
        }
    }
}
