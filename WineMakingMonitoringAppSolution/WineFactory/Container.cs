using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineFactory
{
    public class Container
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContainerId { get; set; }
        public int Capacity { get; set; }
        public bool Empty { get; set; }
        public int LocalId { get; set; }
        public virtual Wine Wine { get; set; }
        
        [ForeignKey("LocalId")]
        public virtual Local Local { get; set; }

        
        
    }
}
