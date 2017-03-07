using System;
using System.Collections.Generic;
using System.Reactive;
using SystemInterfaces;
using Reactive.Bindings;
using ReactiveUI;

namespace ViewModel.Interfaces
{
    
    public interface IViewModel:IProcessSource
    {
        IViewInfo ViewInfo { get; }
        ISystemProcess Process { get; }
        
        List<IViewModelEventSubscription<IViewModel, IEvent>> EventSubscriptions { get; }
        List<IViewModelEventPublication<IViewModel, IEvent>> EventPublications { get; }
        Dictionary<string, ReactiveCommand<IViewModel, Unit>> Commands { get; }
        List<IViewModelEventCommand<IViewModel, IEvent>> CommandInfo { get; }

        ReactiveProperty<RowState> RowState { get; }

        Type Orientation { get; }
        Type ViewModelType { get; }
        int Priority { get; }
    }
}
