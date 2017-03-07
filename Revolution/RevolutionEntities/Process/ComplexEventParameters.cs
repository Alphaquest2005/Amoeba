using System.Collections.Immutable;
using Actor.Interfaces;

namespace RevolutionEntities.Process
{
    public class ComplexEventParameters : IComplexEventParameters
    {
        public ComplexEventParameters(IComplexEventService actor, ImmutableDictionary<string, dynamic> messages)
        {
            Actor = actor;
            Messages = messages;
            
        }

        public IComplexEventService Actor { get; }
        public ImmutableDictionary<string, dynamic> Messages { get; }
     
    }
}