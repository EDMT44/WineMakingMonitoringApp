using DBAcces.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WineMakingMonitoringApp.Services;

namespace WineMakingMonitoringApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Repository repository;

        public App()
        {
            repository = new Repository();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //int initCredit = Convert.ToInt32(ConfigurationManager.AppSettings["initCredit"]);
            //NavigationService.ShowCustomeOrdersWindows(new Customer {Name = "David", Credit = 2524, Orders = new List<Order> {new Order {Car = new Car {Make = "MVC", Price = 512, Color = "#FF12A587"}, Id = 1 } } }, repository);
            NavigationService.ShowMainWindow(repository);
        }
    }
}
