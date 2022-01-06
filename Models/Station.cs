using System;
using System.Collections.Generic;

namespace AlterTankBackend.Models
{
    public class Stations
    {
        public Guid id { get; set; }
        public double latitude { get; set; }
        public double longitude {get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string address { get; set; }
        public string name { get; set;  }
        public string description { get; set; }
        public virtual ICollection<PlugsStations> plugStations { get; set; }
        public virtual ICollection<Prices> prices { get; set; } 
    }
}
