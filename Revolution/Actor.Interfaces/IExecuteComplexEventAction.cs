using SystemInterfaces;

namespace Actor.Interfaces
{
    
    public interface IExecuteComplexEventAction : IProcessSystemMessage
    {
        IProcessAction Action { get; }
        IComplexEventParameters ComplexEventParameters { get; }
    }
}
