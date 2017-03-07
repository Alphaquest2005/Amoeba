﻿// <autogenerated>
//   This file was generated by T4 code generator MRManger-ViewModels.tt.
//   Any changes made to this file manually will be lost next time the file is regenerated.
// </autogenerated>


using System;
using System.Linq;
using SystemInterfaces;
using Core.Common.UI;
using EventAggregator;
using Process.WorkFlow;
using Reactive.Bindings;
using RevolutionEntities.Process;
using RevolutionEntities.ViewModels;
using ViewModel.Interfaces;
using ViewModel.WorkFlow;

namespace ViewModels
{
    
    public class MainWindowViewModel : BaseViewModel<MainWindowViewModel>, IMainWindowViewModel
    {
        private static readonly MainWindowViewModel instance;

        static MainWindowViewModel()
        {
            instance = new MainWindowViewModel();
        }

        public static MainWindowViewModel Instance
        {
            get { return instance; }
        }

        public MainWindowViewModel()
            : base(new SystemProcess(Processes.ProcessInfos.FirstOrDefault(), new Agent("System"), new MachineInfo(Environment.MachineName, Environment.ProcessorCount)),
                  new ViewInfo("MainWindowViewModel", "", ""),
                  ProcessViewModels.ProcessViewModelInfos.FirstOrDefault()?.Subscriptions,
                  ProcessViewModels.ProcessViewModelInfos.FirstOrDefault()?.Publications,
                  ProcessViewModels.ProcessViewModelInfos.FirstOrDefault()?.Commands,
                  ProcessViewModels.ProcessViewModelInfos.FirstOrDefault()?.Orientation,
                  ProcessViewModels.ProcessViewModelInfos.First().Priority)
        {
            this.WireEvents();
            EventMessageBus.Current.GetEvent<IProcessEventFailure>(Source).Subscribe(x => { });
        }


        public ReactiveProperty<IScreenModel> ScreenModel { get; } = new ReactiveProperty<IScreenModel>(); 

        


    }
}
