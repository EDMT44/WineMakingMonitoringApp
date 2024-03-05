
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineMakingMonitoringApp.ViewModels
{
    public abstract class BaseList<T>: BaseViewModel<T>
    {
        public ObservableCollection<BaseDetails<T>> Collection { get; private set; }
        private BaseDetails<T> _selected;
        public BaseDetails<T> Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

        protected BaseList(List<BaseDetails<T>> collection)
        {
            Collection = new ObservableCollection<BaseDetails<T>>(collection);
        }
    }
}
