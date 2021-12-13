using System;
using System.Collections.Generic;

namespace AlterTankBackend.Models
{
    public class Stations
    {
        public Guid id { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string name { get; set;  }
        public string description { get; set; }
        public string lastPrice { get; set; }
        public virtual ICollection<Prices> prices { get; set; }
        public virtual ICollection<Fuels> fuels { get; set; }
        public virtual ICollection<Plugs> plugs { get; set; }
    }
}
