using System.Collections.Generic;
using RevolutionData;
using ViewModel.Interfaces;

namespace ViewModel.WorkFlow
{
    public class ProcessViewModels
    {
        public static readonly List<IViewModelInfo> ProcessViewModelInfos = new List<IViewModelInfo>
        {
            MainWindowViewModelInfo.MainWindowViewModel,
            ScreenViewModelInfo.ScreenViewModel,
            HeaderViewModelInfo.HeaderViewModel,
            FooterViewModelInfo.FooterViewModel,
            
            //ToDo: Cache any Set that load
            //EntityCacheViewModelInfo<ISyntomPriority>.CacheViewModel(3),
            //EntityViewCacheViewModelInfo<IDoctorInfo>.CacheViewModel(3),
           

        };

        public static readonly List<IViewModelInfo> ProcessCache = new List<IViewModelInfo>
        {
            


        };
    }


}
