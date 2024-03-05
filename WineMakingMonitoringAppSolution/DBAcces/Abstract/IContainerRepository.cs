using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace DBAcces.Abstract
{
    public interface IContainerRepository: IDisposable
    {
        void InsertContainer(int capacity, Local local);

        //void UpdateContainer();
        void DeleteContainer(int id);
        void DeleteContainer(Container containerToDelete);
        Container GetContainerByKey(int id);
       // Container GetContainerByWine(int wineId);
        IList<Container> Containers { get; }
        int Count { get; }
        void CommitChanges();
    }
}
