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

        public WineListViewModel Wines { get; set; }
        public List<WineFactory.Container> Containers
        {
            get { return containers; }
            set
            {
                containers = value;
                OnPropertyChanged(nameof(Containers));
                OnPropertyChanged(nameof(EnableAddWineButton));
                OnPropertyChanged(nameof(Texto));
            }
        }
        public void UpdateFreeContainers() 
        { 
            containers= (from c in wineRep.Containers
                         where c.Empty == true
                         select c).ToList();
        }
        public bool EnableAddWineButton
        {
            get
            {
                if (Containers != null && Containers.Count() > 0) { return true; }
                else
                {
                    return false;
                }
            }
        }
        public string Texto
        {
            get
            {
                if (Containers != null) { return "Contenedores disponibles: " + Containers.Count().ToString(); }
                else
                {
                    return "Contenedores disponibles: 0" ;
                }
            }
        }
        public MainWindowsViewModel(Repository rep) : base(new List<BaseDetails<Wine>>())
        {
            wineRep = rep;
            UpdateFreeContainers();
            InsertingWineViewModel.AddedWine += (sender, args) => {
                UpdateFreeContainers();
            };
            Wines = new WineListViewModel(new System.Collections.Generic.List<BaseDetails<Wine>>());
            foreach (var wine in wineRep.Wines)
            {
                Wines.Collection.Add(new WineDetailsViewModel(wine));
            }
            //Wines.PropertyChanged += Wines_PropertyChanged;
        }

        private void Wines_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
           
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
