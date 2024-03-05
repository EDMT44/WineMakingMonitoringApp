using DBAcces.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;
using WineMakingMonitoringApp.ViewModels;
using WineMakingMonitoringApp.Views;

namespace WineMakingMonitoringApp.Services
{
    public static class NavigationService
    {
        public static void ShowMainWindow(Repository rep)
        {
            var window = new MainWindows();
            var viewModel = new MainWindowsViewModel(rep);
            viewModel.ViewTitle = "MainWindow";
            window.DataContext = viewModel;
            viewModel.OnRequestClose += (s, e) => window.Close();
            window.Show();

        }
        //public static void ShowAreaSelectionWindow()
        //{
        //    var window = new AreaSelection();
        //    var viewModel = new AreaSelectionViewModel();
        //    viewModel.ViewTitle = "NewOrder";
        //    window.DataContext = viewModel;
        //    viewModel.OnRequestClose += (s, e) => window.Close();
        //    window.ShowDialog();
        //}
        public static void ShowInsertingWineWindow(Repository rep)
        {
            var window = new InsertingWine();
            var viewModel = new InsertingWineViewModel(rep);
            viewModel.ViewTitle = "NewWine";
            window.DataContext = viewModel;
            viewModel.OnRequestClose += (s, e) => window.Close();
            window.ShowDialog();
        }
        public static void ShowInsertingContainerWindow(Repository rep)
        {
            var window = new InsertingContainer();
            var viewModel = new InsertingContainerViewModel(rep);
            viewModel.ViewTitle = "NewContainer";
            window.DataContext = viewModel;
            viewModel.OnRequestClose += (s, e) => window.Close();
            window.ShowDialog();
        }
        //public static void ShowAreaWindow()
        //{
        //    var window = new Area();
        //    var viewModel = new AreaViewModel();
        //    viewModel.ViewTitle = "NewOrder";
        //    window.DataContext = viewModel;
        //    viewModel.OnRequestClose += (s, e) => window.Close();
        //    window.ShowDialog();
        //}

    }
}
