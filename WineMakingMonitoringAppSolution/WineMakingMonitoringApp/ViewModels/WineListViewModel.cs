using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace WineMakingMonitoringApp.ViewModels
{
    public class WineListViewModel:BaseList<Wine>
    {
        public WineListViewModel(List<BaseDetails<Wine>> collection) : base(collection)
        {

        }
    }
}
