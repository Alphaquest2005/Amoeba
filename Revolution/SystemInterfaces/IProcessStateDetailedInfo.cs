﻿namespace SystemInterfaces
{
    
    public interface IProcessStateInfo
    {
        int ProcessId { get; }
        IState State { get; }
    }
}