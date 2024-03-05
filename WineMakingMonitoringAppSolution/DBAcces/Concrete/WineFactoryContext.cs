using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineFactory;





namespace DBAcces.Concrete
{
    public class WineFactoryContext : DbContext
    {
      
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Local> Local { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=WineFactory;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
        }


        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Wine>().ToTable("Wine");
        //    modelBuilder.Entity<Container>().ToTable("Container");
        //    modelBuilder.Entity<Local>().ToTable("Local");
        //    base.OnModelCreating(modelBuilder);
        //}
    }

}

