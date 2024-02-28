using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAcces
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineID { get; set; }
        //public WineFlavor Flavor { get; set; }
        public float Brix { get; set; }
        public float Density { get; set; }
        public float HoneyWeight { get; set; }
        public float Yeast { get; set; }
        public String Notes { get; set; }
        public int ContainerID { get; set; }
        [ForeignKey("ContainerID")]
        public virtual Container Container { get; set; }
        //public DateTime Date { get; set; }
    }
}
