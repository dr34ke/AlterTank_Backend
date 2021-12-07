using AlterTankBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Controllers
{
    public class StationsController
    {
        [HttpGet]
        public IEnumerable<List<Station>> Get(string latitude, string longitude, string range, string fuelType, string plugType)
        {
           
            return null;
        }

        [HttpGet]
        [Route("[controller]/getBoundingCoordinates")]
        public string getBoundingCoordinates(string latitude, string longitude, string range)
        {
            Geolocation geo = Geolocation.BoundingCoordinates(double.Parse(range), double.Parse(latitude), double.Parse(longitude));
            return geo.ToString();
        }
    }
}
