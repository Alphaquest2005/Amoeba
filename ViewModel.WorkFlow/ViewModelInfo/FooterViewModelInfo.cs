using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using SystemInterfaces;
using ReactiveUI;
using RevolutionEntities.Process;
using RevolutionEntities.ViewModels;
using ViewMessages;
using ViewModel.Interfaces;

namespace RevolutionData
{
}

namespace RevolutionData
{
    public class FooterViewModelInfo
    {
        public static readonly ViewModelInfo FooterViewModel = new ViewModelInfo
            (
            3,
            new ViewInfo("Footer","",""), 
            new List<IViewModelEventSubscription<IViewModel, IEvent>>
            {
                //ToDo: Catch any CurrentEntity
                new ViewEventSubscription<IFooterViewModel, ICurrentEntityChanged<IEntityId>>(
                    3,
                    e => e != null,
                    new List<Func<IFooterViewModel, ICurrentEntityChanged<IEntityId>, bool>>(),
                    (v, e) =>
                    {
                        //if (v.CurrentEntities.Value == e.Entity) return;
                        //v.CurrentPatient.Value = e.Entity;
                    }),

                
            },
            new List<IViewModelEventPublication<IViewModel, IEvent>>{},
            new List<IViewModelEventCommand<IViewModel,IEvent>>
            {

                //ToDo: Catch any CurrentEntity click
                new ViewEventCommand<IFooterViewModel, INavigateToView>(
                    key:"ViewHome",
                    commandPredicate:new List<Func<IFooterViewModel, bool>>{},
                    subject:s => Observable.Empty<ReactiveCommand<IViewModel, Unit>>(),

                    messageData: s => new ViewEventCommandParameter(
                        new object[] {ViewMessageConst.Instance.ViewHome},
                        new StateCommandInfo(s.Process.Id,
                            Context.View.Commands.NavigateToView), s.Process,
                        s.Source)),

                


            },
            typeof(IFooterViewModel),
            typeof(IFooterViewModel), 0);
    }
}