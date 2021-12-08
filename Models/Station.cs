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
        public List<Prices> prices { get; set; }
        public List<Fuels> fuels { get; set; }
        public List<Plugs> plugs { get; set; }
    }
}
