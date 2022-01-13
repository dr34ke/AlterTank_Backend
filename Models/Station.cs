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
    public class StationsWithPrice :Stations
    {
        public StationsWithPrice(Stations station, string price)
        {
            this.lastPrice = price;
            this.latitude = Geolocation.ConvertToDegrees(station.latitude);
            this.longitude = Geolocation.ConvertToDegrees(station.longitude);
            this.description = station.description;
            this.city = station.city;
            this.street = station.street;
            this.name = station.name;
            this.address = station.address;
            this.id = station.id;
        }

        public StationsWithPrice(Stations station)
        {
            this.latitude = Geolocation.ConvertToDegrees(station.latitude);
            this.longitude = Geolocation.ConvertToDegrees(station.longitude);
            this.description = station.description;
            this.city = station.city;
            this.street = station.street;
            this.name = station.name;
            this.address = station.address;
            this.id = station.id;
        }

        public string lastPrice { get; set; }
    }
}
