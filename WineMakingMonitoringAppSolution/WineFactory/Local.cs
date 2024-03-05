using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineFactory
{
    public class Local
    {
        public Local()
        {
            this.Containers= new HashSet<Container>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocalId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Container> Containers { get; set; }
    }
}
