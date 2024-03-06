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
        private WineListViewModel wines;
        public WineListViewModel Wines 
        { 
            get 
            {
                return wines; 
            } 
            set 
            {
                wines = value;
                OnPropertyChanged(); 
            } 
        }
        public List<WineFactory.Container> Containers
        {
            get { return containers; }
            set
            {
                containers = value;
                //OnPropertyChanged(nameof(Containers));
                OnPropertyChanged();
                //OnPropertyChanged(nameof(EnableAddWineButton));
                //OnPropertyChanged(nameof(Texto));
            }
        }
        public void UpdateFreeContainers() 
        { 
            Containers = (from c in wineRep.Containers
                         where c.Empty == true
                         select c).ToList();

            if (Containers != null) { Texto = "Contenedores disponibles: " + Containers.Count().ToString(); }
            else
            {
                Texto = "Contenedores disponibles: 0";
            }
        }
        public void UpdateWines()
        {
            Wines.Collection.Clear();
            foreach (var wine in wineRep.Wines)
            {
                Wines.Collection.Add(new WineDetailsViewModel(wineRep, wine));
            }
        }
        public void UpdateButton()
        {
            if (Containers != null && Containers.Count() > 0) 
            {
                EnableAddWineButton = true; 
            }
            else
            {
                EnableAddWineButton = false;
            }
        }
        private bool enableAddWineButton;
        public bool EnableAddWineButton
        {
            get
            {
                return enableAddWineButton;
                
            }
            set 
            { 
                enableAddWineButton = value;
                OnPropertyChanged();
            }
        }
        private string texto;
        public string Texto
        {
            get
            {
                return texto;
            }
            set 
            {
                texto = value;
                OnPropertyChanged();
            }

        }
        public MainWindowsViewModel(Repository rep) : base(new List<BaseDetails<Wine>>())
        {
            wineRep = rep;
            UpdateFreeContainers();
            UpdateButton();
            InsertingWineViewModel.AddedWine += (sender, args) => {
                UpdateFreeContainers();
                UpdateWines();
                UpdateButton();
            };
            Wines = new WineListViewModel(new System.Collections.Generic.List<BaseDetails<Wine>>());
            UpdateWines();
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
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
