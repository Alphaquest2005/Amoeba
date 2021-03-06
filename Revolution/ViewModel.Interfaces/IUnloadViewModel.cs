﻿using SystemInterfaces;

namespace ViewModel.Interfaces
{
    
    public interface IUnloadViewModel : IProcessSystemMessage
    {
        IViewModelInfo ViewModelInfo { get; }
    }
}