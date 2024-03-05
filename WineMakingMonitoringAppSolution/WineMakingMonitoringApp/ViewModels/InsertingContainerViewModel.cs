using DBAcces.Concrete;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineFactory;
using WineMakingMonitoringApp.Utilities;

namespace WineMakingMonitoringApp.ViewModels
{
    public class InsertingContainerViewModel : BaseList<Local>
    {
       
        private CommandHandler addingContainerCommand;
        public Container Container = new Container();
       

        private Repository rep;
        public int Capacity
        {
            set { Container.Capacity = value; }
        }
        
        public InsertingContainerViewModel(Repository rep) : base(new List<BaseDetails<Local>>())
        {
            this.rep = rep;
            
            foreach (var local in rep.Locals)
            {
                Collection.Add(new LocalDetailsViewModel(new Local
                {
                    Name = local.Name,
                }));
            }
            Selected = Collection.First();
        }
        
        public ICommand AddingContainerCommand
        {
            get
            {
                return addingContainerCommand ?? (addingContainerCommand = new CommandHandler(parameter => AddingContainer(), parameter => true));

            }
        }

        public void AddingContainer()
        {
            rep.InsertContainer(Container.Capacity, Selected.CurrentEntity);
            rep.CommitChanges();
            OnRequestClose?.Invoke(this, null);
        }

        public event EventHandler OnRequestClose;
    }
}
