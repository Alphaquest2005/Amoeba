using System.Collections.Generic;
using SystemInterfaces;

namespace Actor.Interfaces
{
    
    public interface ICreateProcessActor : IProcessSystemMessage
    {
        IList<IComplexEventAction> ComplexEvents { get; }
    }
}
