using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class PlugsStations
    {
        public Guid StationId { get; set; }
        public int PlugId { get; set; }

        public virtual Stations Station { get; set; }
        public virtual Plugs Plug { get; set; }

        public int Count { get; set; }
    }
}
