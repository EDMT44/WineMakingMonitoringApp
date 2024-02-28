using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAcces
{
    public class WineFactoryContext : DbContext
    {
        public WineFactoryContext(DbContextOptions<WineFactoryContext> options)
            : base(options) 
        {

        }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Local> Local { get; set; }

    }
}
