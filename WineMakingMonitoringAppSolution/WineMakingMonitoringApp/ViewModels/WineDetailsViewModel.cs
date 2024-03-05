using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace WineMakingMonitoringApp.ViewModels
{
    public class WineDetailsViewModel:BaseDetails<Wine>
    {
        public WineDetailsViewModel(Wine currentEntity) : base(currentEntity)
        {

        }
        public int WineId { get { return CurrentEntity.WineId; } }
        public string Date { get { return CurrentEntity.Date.Day.ToString()+"/"+ CurrentEntity.Date.Month.ToString()+"/"+ CurrentEntity.Date.Year.ToString(); } }
        public int ContainerId { get { return CurrentEntity.ContainerId; } }
       // public string LocalName { get { return CurrentEntity.Container.Local.Name; } }
    }
}
