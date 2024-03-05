using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMakingMonitoringApp.ViewModels
{
    public abstract class BaseDetails<T>: BaseViewModel<T>
    {
        public T CurrentEntity { get; private set; }

        protected BaseDetails(T currentEntity)
        {
            CurrentEntity = currentEntity;
        }
    }
}
