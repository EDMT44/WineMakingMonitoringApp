using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace WineMakingMonitoringApp.ViewModels
{
    public class LocalDetailsViewModel: BaseDetails<Local>
    {
        public string Name
        {
            get { return CurrentEntity.Name; }
            set
            {
                CurrentEntity.Name = value;
                //OnPropertyChanged(nameof(Name));
            }
        }
       
        public LocalDetailsViewModel(Local currentEntity) : base( currentEntity)
        {

        }
    }
}
