using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WineId { get; set; }
        //public WineFlavor Flavor { get; set; }
        public float InitialBrix { get; set; }
        public float? FinalBrix { get; set; }
        public float InitialDensity { get; set; }
        public float? FinalDensity { get; set; }
        public float HoneyWeight { get; set; }
        public float Yeast { get; set; }
        public string Notes { get; set; }
        public DateTime Date { get; set; }
        public int ContainerId { get; set; }

        [ForeignKey("ContainerId")]
        public virtual Container Container { get; set; }  
        
        
    }
}
