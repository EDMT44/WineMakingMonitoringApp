using DBAcces.Abstract;
using DBAcces.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineFactory;
using WineMakingMonitoringApp.Services;
using WineMakingMonitoringApp.Utilities;

namespace WineMakingMonitoringApp.ViewModels
{
    public class MainWindowsViewModel : BaseList<Wine>
    {
        private Repository wineRep;
        private List<WineFactory.Container> containers;

        private CommandHandler createWineCommand;
        private CommandHandler addContainerCommand;

        public List<WineFactory.Container> Containers
        {
            get { return containers; }
            set
            {
               
                OnPropertyChanged(nameof(Containers));
                OnPropertyChanged(nameof(EnableAddWineButton));
               // OnPropertyChanged(nameof(Texto));
            }
        }
        public bool EnableAddWineButton => Containers.Count()>0;
        public string Texto => "Contenedores disponibles: "+Containers.Count().ToString();
        public MainWindowsViewModel(Repository rep) : base(new List<BaseDetails<Wine>>())
        {
            wineRep = rep;
            containers = (from c in wineRep.Containers
                          where c.Empty == true
                          select c).ToList();
            
        }
        public void CreateWine()
        {
            NavigationService.ShowInsertingWineWindow(wineRep);
        }
        public void AddContainer()
        {
            NavigationService.ShowInsertingContainerWindow(wineRep);
        }
        public ICommand CreateWineCommand
        {
            get
            {
                return createWineCommand ?? (createWineCommand=new CommandHandler(parameter=>CreateWine(),parameter=>true));
            }
        }
        public ICommand AddContainerCommand
        {
            get
            {
                return addContainerCommand ?? (addContainerCommand = new CommandHandler(parameter => AddContainer(), parameter => true));
            }
        }


        public event EventHandler OnRequestClose;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
