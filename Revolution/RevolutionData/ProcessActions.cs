using System;
using System.Collections.Generic;
using SystemInterfaces;
using Actor.Interfaces;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows;
using EventMessages.Commands;
using EventMessages.Events;
using RevolutionEntities.Process;
using Utilities;

namespace RevolutionData
{
    public static class ProcessActions
    {
        public const int NullProcess = -1;
        public static IProcessAction ProcessStarted => new ProcessAction(
                        action: async cp => await Task.Run(() => new SystemProcessStarted(
                            new StateEventInfo(cp.Actor.Process.Id, Context.Process.Events.ProcessStarted),
                            cp.Actor.Process, cp.Actor.Source)),
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.StartProcess),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));

        public static IProcessAction StartProcess => new ProcessAction(
                        action: async cp => await Task.Run(() => new StartSystemProcess(NullProcess,//HACK: to keep this generic, the process that was used to create action will be used
                            new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.StartProcess),
                            cp.Actor.Process, cp.Actor.Source)), 
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.StartProcess),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));

        public static IProcessAction StartProcessWithValidatedUser => new ProcessAction(
                       action: async cp =>  await Task.Run(() => new StartSystemProcess(NullProcess,//HACK: to keep this generic, the process that was used to create action will be used
                           new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.StartProcess), cp.Actor.Process, cp.Actor.Source)),
                       processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.StartProcess),
                       expectedSourceType: new SourceType(typeof(IComplexEventService)));

        public static IProcessAction CompleteProcess => new ProcessAction(
                        action: async cp => await Task.Run(() => new SystemProcessCompleted(new StateEventInfo(cp.Actor.Process.Id, Context.Process.Events.ProcessCompleted),cp.Actor.Process, cp.Actor.Source)),
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.CompleteProcess),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));



        public static IProcessAction CleanUpProcess => new ProcessAction(
                        action: async cp =>  await Task.Run(() => new CleanUpSystemProcess(cp.Actor.Process.Id,new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.CleanUpProcess), cp.Actor.Process, cp.Actor.Source)), 
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.CleanUpProcess),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));

        public static IProcessAction DisplayError => new ProcessAction(
                        action: async cp =>
                        {
                            MessageBox.Show(cp.Messages["ProcessEventError"].Exception.Message + "-----" +
                                            cp.Messages["ProcessEventError"].Exception.StackTrace);


                            return await Task.Run(() => new FailedMessageData(cp, new StateEventInfo(cp.Actor.Process.Id,Context.Process.Events.Error), cp.Actor.Process,cp.Actor.Source));
                        }, 
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.Error),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));
        public static IProcessAction ShutDownApplication => new ProcessAction(
                        action: cp =>
                        {
                            Application.Current.Dispatcher.Invoke(() =>
                            {
                                    MessageBox.Show(cp.Messages["ProcessEventError"].Exception.Message + "-----" +
                                            cp.Messages["ProcessEventError"].Exception.StackTrace);
                                        Application.Current?.Shutdown();
                            
                            });
                            return null;
                        },
                        processInfo: cp => new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.Error),
                        expectedSourceType: new SourceType(typeof(IComplexEventService)));

        public static IProcessAction IntializePulledProcessState<TEntityView>(string entityName) where TEntityView : SystemInterfaces.IEntityView
        {
            return new ProcessAction(
                action: async cp =>
                         await Task.Run(() => new LoadPulledEntityViewSetWithChanges<IExactMatch>(typeof(TEntityView),entityName,new Dictionary<string, dynamic>(),
                            new StateCommandInfo(cp.Actor.Process.Id,
                                Context.EntityView.Commands.LoadEntityViewSetWithChanges),
                            cp.Actor.Process, cp.Actor.Source)),
                processInfo:
                    cp =>
                        new StateCommandInfo(cp.Actor.Process.Id,
                            Context.EntityView.Commands.LoadEntityViewSetWithChanges),
                // take shortcut cud be IntialState
                expectedSourceType: new SourceType(typeof (IComplexEventService)));
        }

        public static IProcessAction UpdateEntityViewState<TEntityView>() where TEntityView : SystemInterfaces.IEntityView
        {
            return new ProcessAction(
                action: async cp =>
                    {
                        var ps = new ProcessState<TEntityView>(
                             process: cp.Actor.Process,
                             entity: cp.Messages["EntityView"].Entity,
                             info: new StateInfo(cp.Actor.Process.Id, new State($"Loaded {typeof(TEntityView).Name} Data", $"Loaded{typeof(TEntityView).Name}", "")));
                        return await Task.Run(() => new UpdateProcessState<TEntityView>(
                                    state: ps,
                                    process: cp.Actor.Process,
                                    processInfo: new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.UpdateState),
                                    source: cp.Actor.Source));
                    },
                processInfo:
                    cp =>
                        new StateCommandInfo(cp.Actor.Process.Id,
                            Context.Process.Commands.UpdateState),
                // take shortcut cud be IntialState
                expectedSourceType: new SourceType(typeof(IComplexEventService)));
        }

        public static IProcessAction UpdateEntityViewStateList<TEntityView>() where TEntityView : SystemInterfaces.IEntityView
        {
            return new ProcessAction(
                action: async cp =>
                    {
                        var ps = new ProcessStateList<TEntityView>(
                             process: cp.Actor.Process,
                             entity: ((List<TEntityView>)cp.Messages["EntityViewSet"].EntitySet).FirstOrDefault(),
                             entitySet: cp.Messages["EntityViewSet"].EntitySet,
                             selectedEntities: new List<TEntityView>(),
                             stateInfo: new StateInfo(cp.Actor.Process.Id, new State($"Loaded {typeof(TEntityView).Name} Data", $"Loaded{typeof(TEntityView).Name}", "")));
                        return await Task.Run(() => new UpdateProcessStateList<TEntityView>(
                                    state: ps,
                                    process: cp.Actor.Process,
                                    processInfo: new StateCommandInfo(cp.Actor.Process.Id, Context.Process.Commands.UpdateState),
                                    source: cp.Actor.Source));
                    },
                processInfo:
                    cp =>
                        new StateCommandInfo(cp.Actor.Process.Id,
                            Context.Process.Commands.UpdateState),
                // take shortcut cud be IntialState
                expectedSourceType: new SourceType(typeof(IComplexEventService)));
        }

        public static IProcessAction RequestState<TEntityView>(Expression<Func<TEntityView, object>> property) where TEntityView : SystemInterfaces.IEntityView
        {
            return new ProcessAction(
                action: async cp =>
                {

                    var key = default(TEntityView).GetMemberName(property);
                    var value = cp.Messages["CurrentEntity"].Entity.Id;
                    var changes = new Dictionary<string, dynamic>() { { key, value } };
                    return await Task.Run(() => new GetEntityViewWithChanges<TEntityView>(changes,
                         new StateCommandInfo(cp.Actor.Process.Id, Context.EntityView.Commands.GetEntityView),
                         cp.Actor.Process, cp.Actor.Source));
                },
                processInfo: cp =>
                    new StateCommandInfo(cp.Actor.Process.Id,
                        Context.EntityView.Commands.GetEntityView),
                // take shortcut cud be IntialState
                expectedSourceType: new SourceType(typeof(IComplexEventService))

                );
        }


        public static IProcessAction RequestStateList<TCurrentEntity, TEntityView>( Expression<Func<TCurrentEntity, object>> currentProperty, Expression<Func<TEntityView, object>> viewProperty) where TEntityView : SystemInterfaces.IEntityView
        {
            return new ProcessAction(
                action: async cp =>
                {
                    
                    var key = default(TEntityView).GetMemberName(viewProperty);
                    var value = currentProperty.Compile().Invoke(cp.Messages["CurrentEntity"].Entity);
                    var changes = new Dictionary<string, dynamic>() { {key,value} };
                    return await Task.Run(() => new LoadEntityViewSetWithChanges<TEntityView, IExactMatch>(changes,
                        new StateCommandInfo(cp.Actor.Process.Id, Context.EntityView.Commands.GetEntityView),
                        cp.Actor.Process, cp.Actor.Source));
                },
                processInfo: cp =>
                    new StateCommandInfo(cp.Actor.Process.Id,
                        Context.EntityView.Commands.GetEntityView),
                // take shortcut cud be IntialState
                expectedSourceType: new SourceType(typeof (IComplexEventService))

                );
        }


    }

    public partial class EntityComplexActions<TEntity> where TEntity : IEntity
    {
        public static ComplexEventAction IntializeCache(int processId)
        {
            return new ComplexEventAction(
                key: $"{typeof(TEntity).Name}EntityCache-1",
                processId: processId,
                events: new List<IProcessExpectedEvent>
                {
                    new ProcessExpectedEvent(key: "ProcessStarted",
                        processId: processId,
                        eventPredicate: e => e != null,
                        eventType: typeof (ISystemProcessStarted),
                        processInfo: new StateEventInfo(processId, Context.Process.Events.ProcessStarted),
                        expectedSourceType: new SourceType(typeof (IComplexEventService)))

                },
                expectedMessageType: typeof(IProcessStateMessage<TEntity>),
                action: IntializeCacheAction,
                processInfo: new StateCommandInfo(processId, Context.Process.Commands.CreateState));
        }

        /// 
        public static IProcessAction IntializeCacheAction => new ProcessAction(
            action: async cp =>
                    await Task.Run(() => new LoadEntitySet<TEntity>(
                        new StateCommandInfo(3, Context.EntityView.Commands.LoadEntityViewSetWithChanges),
                        cp.Actor.Process, cp.Actor.Source)),
            processInfo:
                cp =>
                    new StateCommandInfo(cp.Actor.Process.Id,
                        Context.EntityView.Commands.LoadEntityViewSetWithChanges),
            // take shortcut cud be IntialState
            expectedSourceType: new SourceType(typeof(IComplexEventService)));

    }

    public partial class EntityViewComplexActions<TView> where TView : SystemInterfaces.IEntityView
    {

        public static ComplexEventAction IntializeCache(int processId)
        {
            return new ComplexEventAction(
                key: $"{typeof(TView).Name}EntityViewCache-1",
                processId: processId,
                events: new List<IProcessExpectedEvent>
                {
                        new ProcessExpectedEvent(key: "ProcessStarted",
                            processId: processId,
                            eventPredicate: e => e != null,
                            eventType: typeof (ISystemProcessStarted),
                            processInfo: new StateEventInfo(processId, Context.Process.Events.ProcessStarted),
                            expectedSourceType: new SourceType(typeof (IComplexEventService)))

                },
                expectedMessageType: typeof(IProcessStateMessage<TView>),
                action: IntializeCacheAction,
                processInfo: new StateCommandInfo(processId, Context.Process.Commands.CreateState));
        }


        /// 
        public static IProcessAction IntializeCacheAction => new ProcessAction(
            action: async cp =>
                     await Task.Run(() => new LoadEntityViewSetWithChanges<TView, IExactMatch>(new Dictionary<string, dynamic>(),
                        new StateCommandInfo(3, Context.EntityView.Commands.LoadEntityViewSetWithChanges),
                        cp.Actor.Process, cp.Actor.Source)),
            processInfo:
                cp =>
                    new StateCommandInfo(cp.Actor.Process.Id,
                        Context.EntityView.Commands.LoadEntityViewSetWithChanges),
            // take shortcut cud be IntialState
            expectedSourceType: new SourceType(typeof(IComplexEventService)));

    }
}
