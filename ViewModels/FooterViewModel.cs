using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using SystemInterfaces;
using Core.Common.UI;
using ViewModel.Interfaces;

namespace ViewModels
{

    [Export(typeof(IFooterViewModel))]
    public class FooterViewModel : DynamicViewModel<ObservableViewModel>, IFooterViewModel
    {
        [ImportingConstructor]
        public FooterViewModel(ISystemProcess process, IViewInfo viewInfo, List<IViewModelEventSubscription<IViewModel, IEvent>> eventSubscriptions, List<IViewModelEventPublication<IViewModel, IEvent>> eventPublications, List<IViewModelEventCommand<IViewModel, IEvent>> commandInfo, Type orientation, int priority) : base(new ObservableViewModel(viewInfo, eventSubscriptions, eventPublications, commandInfo, process, orientation, priority))
        {
            this.WireEvents();
        }

        
        
    }
}
