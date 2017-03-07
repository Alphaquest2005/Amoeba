using System.Collections.Immutable;

namespace Actor.Interfaces
{
    
    public interface IComplexEventParameters
    {
        IComplexEventService Actor { get; }
        ImmutableDictionary<string, dynamic> Messages { get; }
       
    }
}