using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace WineMakingMonitoringApp.ViewModels
{
    public class LocalListViewModel:BaseList<Local>
    {
        public LocalListViewModel(List<BaseDetails<Local>> collection) : base(collection)
        {

        }
    }
}
