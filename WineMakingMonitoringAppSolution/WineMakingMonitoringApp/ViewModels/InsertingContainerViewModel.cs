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
        public LocalListViewModel Locals { get; set; }

        private Repository rep;
        public int Capacity
        {
            set { Container.Capacity = value; }
        }
        
        public InsertingContainerViewModel(Repository rep) : base(new List<BaseDetails<Local>>())
        {
            this.rep = rep;
            Locals = new LocalListViewModel(new List<BaseDetails<Local>>());
            foreach (var local in rep.Locals)
            {
                Locals.Collection.Add(new LocalDetailsViewModel(local));
            }
            Locals.Selected = Locals.Collection.First();
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
            rep.InsertContainer(Container.Capacity, Locals.Selected.CurrentEntity);
            rep.CommitChanges();
            OnRequestClose?.Invoke(this, null);
        }

        public event EventHandler OnRequestClose;
    }
}
