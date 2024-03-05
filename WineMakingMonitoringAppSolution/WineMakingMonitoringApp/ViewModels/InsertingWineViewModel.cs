using DBAcces.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WineFactory;
using WineMakingMonitoringApp.Utilities;

namespace WineMakingMonitoringApp.ViewModels
{
    public class InsertingWineViewModel : BaseDetails<Wine>
    {
        private Repository rep;
        private CommandHandler addWineCommand;
        //private CommandHandler cancel;
        #region Properties

        public float InitialBrix
        {
            get { return CurrentEntity.InitialBrix; }
            set { CurrentEntity.InitialBrix = value; }
        }
        public float InitialDensity
        {
            get { return CurrentEntity.InitialDensity; }
            set { CurrentEntity.InitialDensity = value; }
        }
        public float HoneyWeight
        {
            get { return CurrentEntity.HoneyWeight; }
            set { CurrentEntity.HoneyWeight = value; }
        }
        public float Yeast
        {
            get { return CurrentEntity.Yeast; }
            set { CurrentEntity.Yeast = value; }
        }
        public DateTime Date
        {
            get { return CurrentEntity.Date; }
            set { CurrentEntity.Date = value; }
        }
        public string Notes
        {
            get { return CurrentEntity.Notes; }
            set { CurrentEntity.Notes = value; }
        }
        #endregion
        public InsertingWineViewModel(Repository rep) : base(new Wine())
        {
            this.rep = rep;
        }

        public void AddWine()
        {
            rep.InsertWine(InitialBrix, InitialDensity, HoneyWeight, Yeast, Notes, Date);
            rep.CommitChanges();
            AddedWine?.Invoke(this, EventArgs.Empty);
            OnRequestClose?.Invoke(this, null);
        }
        public ICommand AddWineCommand
        {
            get
            {
                return addWineCommand ??= new CommandHandler(parameter => AddWine(), parameter => true);
            }
        }
        public static event EventHandler AddedWine;

        public event EventHandler OnRequestClose;

    }
}
