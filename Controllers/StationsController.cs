using AlterTankBackend.Database;
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
        readonly DBContext Context;
        public StationsController(DBContext dBContext)
            => Context = dBContext;

        [HttpGet]
        public IEnumerable<List<Stations>> Get(string latitude, string longitude, string range, string fuelType, string plugType)
        {
            Geolocation geo = Geolocation.BoundingCoordinates(double.Parse(range), double.Parse(latitude), double.Parse(longitude));
            return null;
        }


    }
}

