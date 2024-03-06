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
        private CommandHandler deleteWineCommand;
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
                OnPropertyChanged();
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
            //Selected = Wines.Collection.First();
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
            InsertingContainerViewModel.AddedContainer += (sender, args) => {
                UpdateFreeContainers();
                UpdateButton();
            };
            Wines = new WineListViewModel(new System.Collections.Generic.List<BaseDetails<Wine>>());
            UpdateWines();
            //Wines.PropertyChanged += Wines_PropertyChanged;
            Wines.PropertyChanged += Wines_PropertyChanged;
        }

        private void Wines_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Selected")
                DeleteWineCommand.RaiseCanExecuteChanged(sender, e);
        }

        public void CreateWine()
        {
            NavigationService.ShowInsertingWineWindow(wineRep);
        }
        public void AddContainer()
        {
            NavigationService.ShowInsertingContainerWindow(wineRep);
        }
        public void DeleteWine(WineDetailsViewModel wineToRemove)
        {
            wineRep.DeleteWine(wineToRemove.WineId);
            wineRep.CommitChanges();
            UpdateButton();
            UpdateFreeContainers();
            UpdateWines();
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
        public CommandHandler DeleteWineCommand
        {
            get
            {
                return deleteWineCommand ?? (deleteWineCommand = new CommandHandler(parameter => DeleteWine((WineDetailsViewModel)Wines.Selected), parameter => Wines.Selected!=null));
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
