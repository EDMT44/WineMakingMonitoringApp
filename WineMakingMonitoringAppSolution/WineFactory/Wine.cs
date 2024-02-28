using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineFactory
{
    public enum WineFlavor {Miel,Guayaba,Tamarindo,Pera,Jambolan }
    public enum WineState { AlcoholFerm, MalolFerm, Finished, NotForSale}
    //public enum Months { January, February, March, April, May, June, July, August, September, October, November, December}
    
    public class Wine
    {
        #region Properties
        int ID { get; set; }
        WineFlavor Flavor { get; set; }
        float Brix { get; set; }
        float Density { get; set; }
        float HoneyWeight { get; set; }
        float Yeast { get; set; }
        String Notes { get; set; }
        DateTime Date { get; set; }

        #endregion
        #region Constructors
        public Wine(int iD, WineFlavor flavor, float brix, float density, float honeyWeight, float yeast, string notes, DateTime date)
        {
            ID = iD;
            Flavor = flavor;
            Brix = brix;
            Density = density;
            HoneyWeight = honeyWeight;
            Yeast = yeast;
            Notes = notes;
            Date = date;
        }

        #endregion
        #region Methods
        public double Age() {
            return (DateTime.Now - Date).TotalDays;
        }
        #endregion
        #region Events

        #endregion
    }
}
