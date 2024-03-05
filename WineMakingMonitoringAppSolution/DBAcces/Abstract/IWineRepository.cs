using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace DBAcces.Abstract
{
    public interface IWineRepository:IDisposable
    {
        void InsertWine( float initialBrix, float initialDensity, float honeyWeight, float yeast, string notes, DateTime date);
        void UpdateWine(int id, float finalBrix, float finalDensity);
        void DeleteWine(int id);
        void DeleteWine(Wine wineToDelete);
        //bool CanAddWine();
        Wine GetWineByKey(int id);
        IList<Wine> Wines { get; }
        IList<Wine> GetWinesByDate(DateTime date);
        //IList<Wine> GetWinesByFlavor(WineFlavor flavor);
        int Count { get; }
        void CommitChanges();
    }
}
