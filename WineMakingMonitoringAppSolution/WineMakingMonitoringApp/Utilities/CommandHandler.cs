using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WineMakingMonitoringApp.Utilities
{
    public class CommandHandler : ICommand
    {
        private Action<object> action;
        private Predicate<object> canExecute;
        public CommandHandler(Action<object> action, Predicate<object> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action(parameter);
        }

        public void RaiseCanExecuteChanged(object sender, EventArgs args)
        {
            CanExecuteChanged?.Invoke(sender, args);
        }
    }
}
