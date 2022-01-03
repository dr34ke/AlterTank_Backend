using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class Plugs
    {
        public int id { get; set; }
        public Fuels fuel { get; set; }
        public string plugName { get; set; }
        public int fuelId { get; set; }
        public virtual ICollection<PlugsStations> PlugsStations { get; set; }
    }
}
