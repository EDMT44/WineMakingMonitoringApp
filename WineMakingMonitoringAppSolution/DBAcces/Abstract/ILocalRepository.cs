using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace DBAcces.Abstract
{
    public interface ILocalRepository:IDisposable
    {
        void InsertLocal();
        void UpdateLocal();
        void DeleteLocal(int id);
        void DeleteLocal(Local localToDelete);
        Local GetLocalByKey(int id);
        Local GetLocalByName(string name);
        IList<Local> Locals{ get; }
        int Count { get; }
        void CommitChanges();
    }
}
