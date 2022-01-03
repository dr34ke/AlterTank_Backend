using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class Fuels
    {
        [Key]
        public int id { get; set; }
        public string fuelName { get; set; }
        public ICollection<Plugs> plugs { get; set; }
    }
}
