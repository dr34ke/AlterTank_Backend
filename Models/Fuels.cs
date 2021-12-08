using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class Fuels
    {
        public Guid id { get; set; }
        public string fuelName { get; set; }
        public List<Plugs> plugs { get; set; }
    }
}
