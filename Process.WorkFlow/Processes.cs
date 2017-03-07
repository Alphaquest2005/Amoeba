using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SystemInterfaces;
using Actor.Interfaces;
using EventMessages.Commands;
using RevolutionData;
using RevolutionEntities.Process;
using Utilities;
using ViewModel.Interfaces;

namespace Process.WorkFlow
{
    

    public static class Processes
    {
        public static readonly List<IProcessInfo> ProcessInfos = new List<IProcessInfo>
        {
            //new Process(0,0, "Uknown Process", "Unknown Process", "Unknown"),
            new ProcessInfo(1, 0, "Starting System", "Prepare system for Intial Use", "Start","System"),
            new ProcessInfo(2, 1, "User SignOn", "User Login", "User","System"),
            
        };



        public static List<IComplexEventAction> ProcessComplexEvents = new List<IComplexEventAction>
        {
             new ComplexEventAction(
                "100",
                1, new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent ("ServiceManagerStarted", 1, typeof (IServiceStarted<IServiceManager>), e => e != null, new StateEventInfo(1, RevolutionData.Context.Actor.Events.ActorStarted), new SourceType(typeof(IServiceManager))),
                    
                },
                typeof(ISystemProcessStarted),
                processInfo:new StateCommandInfo(1,RevolutionData.Context.Process.Commands.StartProcess ),
                action: ProcessActions.ProcessStarted),

             

            new ComplexEventAction(
                "102",
                1, new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent ("ProcessStarted", 1, typeof (ISystemProcessStarted), e => e != null, new StateEventInfo(1, RevolutionData.Context.Process.Events.ProcessStarted), new SourceType(typeof(IProcessService))),
                    new ProcessExpectedEvent ("ViewCreated", 1, typeof (IViewModelCreated<IScreenModel>), e => e != null, new StateEventInfo(1,"ScreenViewCreated", "ScreenView Created","This view contains all views", RevolutionData.Context.ViewModel.Commands.CreateViewModel), new SourceType(typeof(IViewModelService) )),
                    new ProcessExpectedEvent ("ViewLoaded", 1, typeof (IViewModelLoaded<IMainWindowViewModel,IScreenModel>), e => e != null, new StateEventInfo(1,"ScreenViewLoaded","ScreenView Model loaded in MainWindowViewModel","Only ViewModel in Body", RevolutionData.Context.ViewModel.Commands.LoadViewModel), new SourceType(typeof(IViewModelService) ))
                },
                typeof(ISystemProcessCompleted),
                processInfo:new StateCommandInfo(1,RevolutionData.Context.Process.Commands.CompleteProcess ),
                action: ProcessActions.CompleteProcess),

           new ComplexEventAction(
                "103",
                1, new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent ("ProcessCompleted", 1, typeof (ISystemProcessCompleted), e => e != null, new StateEventInfo(1, RevolutionData.Context.Process.Events.ProcessCompleted), new SourceType(typeof(IComplexEventService))),

                },
                typeof(ISystemProcessStarted),
                processInfo:new StateCommandInfo(1,RevolutionData.Context.Process.Commands.StartProcess),
                action: ProcessActions.StartProcess),

            new ComplexEventAction(
                "104",
                1, new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent ("ProcessCompleted", 1, typeof (ISystemProcessCompleted), e => e != null, new StateEventInfo(1, RevolutionData.Context.Process.Events.ProcessCompleted), new SourceType(typeof(IComplexEventService))),

                },
                typeof(ISystemProcessCleanedUp),
                processInfo:new StateCommandInfo(1,RevolutionData.Context.Process.Commands.CleanUpProcess ),
                action: ProcessActions.CleanUpProcess),

            
            //new ComplexEventAction(
            //    "106",
            //    1, new List<IProcessExpectedEvent>
            //    {
            //        new ProcessExpectedEvent ("ProcessEventError", 1, typeof (IProcessEventFailure), e => e != null, new StateEventInfo(1, Context.Process.Events.Error), new SourceType(typeof(IComplexEventService))),

            //    },
            //    typeof(IProcessEventFailure),
            //    processInfo:new StateCommandInfo(1,Context.Process.Commands.Error ),
            //    action: ProcessActions.ShutDownApplication),

            
             new ComplexEventAction(
                "300",
                2, new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent ("ProcessServiceStarted", 3, typeof (IServiceStarted<IProcessService>), e => e != null, new StateEventInfo(3, RevolutionData.Context.Actor.Events.ActorStarted), new SourceType(typeof(IProcessService))),

                },
                typeof(ISystemProcessStarted),
                processInfo:new StateCommandInfo(3,RevolutionData.Context.Process.Commands.StartProcess ),
                action: ProcessActions.ProcessStarted),



           
        };

        public static class ComplexActions
        {
            public static ComplexEventAction IntializePulledProcessState<TEntityView>(int processId, string entityName) where TEntityView : SystemInterfaces.IEntityView
            {
                return new ComplexEventAction(

                    key: $"InitalizeProcessState-{typeof(TEntityView).GetFriendlyName()}",
                    processId: processId,
                    events: new List<IProcessExpectedEvent>
                    {
                        new ProcessExpectedEvent(key: "ProcessStarted",
                            processId: processId,
                            eventPredicate: e => e != null,
                            eventType: typeof (ISystemProcessStarted),
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Process.Events.ProcessStarted),
                            expectedSourceType: new SourceType(typeof (IComplexEventService))),
                        
                    },
                    expectedMessageType: typeof (IProcessStateMessage<TEntityView>),
                    action: ProcessActions.IntializePulledProcessState<TEntityView>(entityName),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.CreateState));
            }


            public static ComplexEventAction UpdateState<TEntityView>(int processId) where TEntityView : SystemInterfaces.IEntityView
            {
                return new ComplexEventAction(
                    key: $"UpdateState-{typeof(TEntityView).GetFriendlyName()}",
                    processId: processId,
                    actionTrigger: ActionTrigger.Any, 
                    events: new List<IProcessExpectedEvent>
                    {
                                new ProcessExpectedEvent<IEntityViewWithChangesUpdated<TEntityView>> (processId: processId,
                            eventPredicate: e => e.Entity != null,
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityUpdated),
                            expectedSourceType: new SourceType(typeof(IEntityRepository)),
                            key: "EntityView"),
                                   new ProcessExpectedEvent<IEntityViewWithChangesFound<TEntityView>> (processId: processId,
                            eventPredicate: e => e.Entity != null,
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityFound),
                            expectedSourceType: new SourceType(typeof(IEntityRepository)),
                            key: "EntityView"),
                                   new ProcessExpectedEvent<IEntityFound<TEntityView>> (processId: processId,
                            eventPredicate: e => e.Entity != null,
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityFound),
                            expectedSourceType: new SourceType(typeof(IEntityRepository)),
                            key: "EntityView")
                    },
                    expectedMessageType: typeof(IProcessStateMessage<TEntityView>),
                    action: ProcessActions.UpdateEntityViewState<TEntityView>(),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.UpdateState));
            }

            
            public static ComplexEventAction RequestState<TCurrentEntity, TEntityView>(int processId, Expression<Func<TEntityView, dynamic>> property) where TEntityView : SystemInterfaces.IEntityView where TCurrentEntity : IEntityId
            {
                return new ComplexEventAction(
                    key: $"RequestState-{typeof(TEntityView).GetFriendlyName()}",
                    processId: processId,
                    actionTrigger: ActionTrigger.Any, 
                    events: new List<IProcessExpectedEvent>
                    {
                        new ProcessExpectedEvent<ICurrentEntityChanged<TCurrentEntity>>(
                            "CurrentEntity", processId, e => e.Entity != null,
                            expectedSourceType: new SourceType(typeof (IViewModel)),
                            //todo: check this cuz it comes from viewmodel
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Process.Events.CurrentEntityChanged)),

                        new ProcessExpectedEvent<IEntityFound<TCurrentEntity>>(
                            "CurrentEntity", processId, e => e.Entity != null,
                            expectedSourceType: new SourceType(typeof (IViewModel)),
                            //todo: check this cuz it comes from viewmodel
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityFound)),
                        new ProcessExpectedEvent<IEntityUpdated<TCurrentEntity>>(
                            "CurrentEntity", processId, e => e.Entity != null,
                            expectedSourceType: new SourceType(typeof (IViewModel)),
                            //todo: check this cuz it comes from viewmodel
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityUpdated)),
                        new ProcessExpectedEvent<IEntityViewWithChangesFound<TCurrentEntity>>(
                            "CurrentEntity", processId, e => e.Entity != null,
                            expectedSourceType: new SourceType(typeof (IViewModel)),
                            //todo: check this cuz it comes from viewmodel
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.EntityView.Events.EntityViewFound))
                    },
                    expectedMessageType: typeof(IProcessStateMessage<TEntityView>),
                    action: ProcessActions.RequestState(property),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.UpdateState));
            }

           


            public static ComplexEventAction UpdateStateList<TEntityView>(int processId) where TEntityView : SystemInterfaces.IEntityView
            {
                return new ComplexEventAction(
                    key: $"UpdateStateList-{typeof(TEntityView).GetFriendlyName()}",
                    processId: processId,
                    events: new List<IProcessExpectedEvent>
                    {
                            new ProcessExpectedEvent<IEntityViewSetWithChangesLoaded<TEntityView>> (
                        "EntityViewSet",processId, e => e.EntitySet != null, expectedSourceType: new SourceType(typeof(IEntityViewRepository)),
                        processInfo: new StateEventInfo(processId, RevolutionData.Context.EntityView.Events.EntityViewSetLoaded))
                    },
                    expectedMessageType: typeof(IProcessStateList<TEntityView>),
                    action: ProcessActions.UpdateEntityViewStateList<TEntityView>(),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.UpdateState));
            }
            public static ComplexEventAction RequestStateList<TCurrentEntity,TEntityView>(int processId, Expression<Func<TCurrentEntity, object>> currentProperty, Expression<Func<TEntityView, object>> viewProperty) where TEntityView : SystemInterfaces.IEntityView where TCurrentEntity:IEntityId
            {
                return new ComplexEventAction(
                    key: $"RequestStateList-{typeof(TCurrentEntity).GetFriendlyName()}-{typeof(TEntityView).GetFriendlyName()}",
                    processId: processId,
                    actionTrigger: ActionTrigger.Any, 
                    events: new List<IProcessExpectedEvent>
                    {
                        new ProcessExpectedEvent<ICurrentEntityChanged<TCurrentEntity>>(
                            "CurrentEntity", processId, e => e.Entity != null,
                            expectedSourceType: new SourceType(typeof (IViewModel)),
                            //todo: check this cuz it comes from viewmodel
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Process.Events.CurrentEntityChanged)),
                        
                    },
                    expectedMessageType: typeof(IProcessStateMessage<TEntityView>),
                    action: ProcessActions.RequestStateList(currentProperty,viewProperty),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.UpdateState));
            }

            public static IComplexEventAction UpdateStateWhenDataChanges<TEntity, TView>(int processId, Expression<Func<TEntity, object>> currentProperty, Expression<Func<TView, object>> viewProperty) where TEntity : IEntityId where TView : SystemInterfaces.IEntityView
            {
                return new ComplexEventAction(
                    key: $"Update{typeof(TEntity).Name}-{typeof(TView).Name}",
                    processId: 3,
                    actionTrigger:ActionTrigger.Any, 
                    events: new List<IProcessExpectedEvent>
                    {
                        new ProcessExpectedEvent<IEntityUpdated<TEntity>>(processId: processId,
                            eventPredicate: e => e.Entity != null,
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.Entity.Events.EntityUpdated),
                            expectedSourceType: new SourceType(typeof (IEntityRepository)),
                            key: "UpdatedEntity"),
                        new ProcessExpectedEvent<IEntityViewWithChangesUpdated<TEntity>>(processId: processId,
                            eventPredicate: e => e.Entity != null,
                            processInfo: new StateEventInfo(processId, RevolutionData.Context.EntityView.Events.EntityViewUpdated),
                            expectedSourceType: new SourceType(typeof (IEntityRepository)),
                            key: "UpdatedEntity"),


                    },
                    expectedMessageType: typeof(IProcessStateMessage<TView>),
                    action: GetView(currentProperty, viewProperty),
                    processInfo: new StateCommandInfo(processId, RevolutionData.Context.Process.Commands.UpdateState));
            }

            public static IProcessAction GetView<TEntity,TView>(Expression<Func<TEntity, object>> currentProperty, Expression<Func<TView, object>> viewProperty) where TView : SystemInterfaces.IEntityView
            {
                return new ProcessAction(
                    action:
                        async cp =>
                        {
                            var key = default(TView).GetMemberName(viewProperty);
                            var value = currentProperty.Compile().Invoke(cp.Messages["UpdatedEntity"].Entity);
                            var changes = new Dictionary<string, dynamic>() { { key, value } };

                            return await Task.Run(() => new GetEntityViewWithChanges<TView>(changes,
                                new StateCommandInfo(cp.Actor.Process.Id, RevolutionData.Context.EntityView.Commands.GetEntityView),
                                cp.Actor.Process, cp.Actor.Source));
                        },
                    processInfo: cp =>
                        new StateCommandInfo(cp.Actor.Process.Id,
                            RevolutionData.Context.EntityView.Commands.GetEntityView),
                    // take shortcut cud be IntialState
                    expectedSourceType: new SourceType(typeof(IComplexEventService))

                    );
            }


        }
    }


}

