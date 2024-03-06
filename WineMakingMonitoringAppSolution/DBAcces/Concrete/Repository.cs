using DBAcces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;

namespace DBAcces.Concrete
{
    public class Repository : IWineRepository, IContainerRepository, ILocalRepository
    {

        WineFactoryContext context = null;
        public Repository()
        {
            context = new WineFactoryContext();
        }

        #region Implementing IWineRepo
        public IList<Wine> Wines
        {
            get
            {
                return context.Wines.ToList();
            }
        }

        int IWineRepository.Count { get { return context.Wines.Count(); } }

        public void DeleteWine(int id)
        {
            var wineToDelete = context.Wines.FirstOrDefault(c => c.WineId == id);
            if (wineToDelete != null)
            {
                context.Wines.Remove(wineToDelete);
                GetContainerByKey(wineToDelete.ContainerId).Empty = true;
            }
        }

        public void DeleteWine(Wine wineToDelete)
        {
            context.Wines.Remove(wineToDelete);
            context.Containers.FirstOrDefault(c => c.Wine.WineId == wineToDelete.WineId).Empty = false;
        }
        

        public Wine GetWineByKey(int id) => context.Wines.Find(id);

        public IList<Wine> GetWinesByDate(DateTime date)
        {
            var wines = from w in context.Wines
                        where w.Date == date
                        select w;
            return Wines;
        }
        //public bool CanAddWine()
        //{
        //    var freeContainers = from c in context.Containers
        //                         where c.Empty == true
        //                         select c;
        //    return freeContainers.Any();
        //}

        //public IList<Wine> GetWinesByFlavor(WineFlavor flavor)
        //{
        //    var wines = from w in context.Wines
        //                where w.Flavor == flavor
        //                select w;
        //    return Wines;
        //}

        public void InsertWine( float initialBrix, float initialDensity, float honeyWeight, float yeast, string notes, DateTime date)
        {
            var containers = from c in context.Containers
                             where c.Empty == true
                             select c;
            if (containers != null)
            {
                context.Wines.Add(new Wine
                {
                    Container = containers.First(),
                    //Flavor = flavor,
                    InitialBrix = initialBrix,
                    InitialDensity = initialDensity,
                    HoneyWeight = honeyWeight,
                    Yeast = yeast,
                    Notes = notes,
                    Date = date
                });
                GetContainerByKey(containers.First().ContainerId).Empty = false;
            }
            else { throw new Exception("No hay contenedores vacios"); }

        }

        public void UpdateWine(int id, float finalBrix, float finalDensity)
        {
            var wine = GetWineByKey(id);
            if (wine == null)
                throw new ArgumentException("El vino a actualizar no existe");
            wine.FinalDensity = finalDensity;
            wine.FinalBrix = finalBrix;
            //////////////////////////////////////////////
        }
        #endregion

        #region Implementing IContainerRepo


        public IList<Container> Containers
        {
            get { return context.Containers.ToList(); }
        }

        int IContainerRepository.Count { get { return context.Containers.Count(); } }


        public void InsertContainer(int capacity, Local local)
        {
            context.Containers.Add(new Container { Capacity = capacity, Empty = true, LocalId = local.LocalId}) ;
        }

        public void DeleteContainer(int id)
        {
            var containerToDelete = context.Containers.FirstOrDefault(c => c.ContainerId == id);
            if (containerToDelete != null)
                context.Containers.Remove(containerToDelete);
        }

        public void DeleteContainer(Container containerToDelete) => context.Containers.Remove(containerToDelete);
        

        public Container GetContainerByKey(int id)
        {
            return context.Containers.Find(id);
        }
        #endregion

        #region Implementing ILocalRepo
        public IList<Local> Locals { get { return context.Local.ToList(); } }

        int ILocalRepository.Count { get { return context.Local.Count(); } }
        public void InsertLocal()
        {
            //context.Local.Add(new Local { });
        }

        public void DeleteLocal(int id)
        {
            //var localToDelete = context.Local.Find(id);
            //if (localToDelete != null)
            //    context.Local.Remove(localToDelete);
        }

        public void DeleteLocal(Local localToDelete)
        {
            //context.Local.Remove(localToDelete);
        }

        public Local GetLocalByKey(int id)
        {
            return context.Local.Find(id);
        }
        public Local GetLocalByName(string name)
        {
            return context.Local.FirstOrDefault(x => x.Name == name);
        }

        public void UpdateLocal()
        {
            //Falta implementar
        }
        #endregion
        public void Dispose()
        {
            context.Dispose();
        }
        public void CommitChanges()
        {
            context.SaveChanges();
        }
    }
}
