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
        [Route("[controller/GetInRange]")]
        public List<Stations> GetInRange(string latitude, string longitude, string range, string fuelType, string plugType)
        {
            Geolocation geo = Geolocation.BoundingCoordinates(double.Parse(range), double.Parse(latitude), double.Parse(longitude));
            List<Stations> stations = Context.Station.Where(
                    item => item.plugs.Any(_item => _item.plugName == plugType && _item.fuel.fuelName == fuelType)
                    &&
                    double.Parse(item.latitude) >= geo.min[0]
                    &&
                    double.Parse(item.latitude) <= geo.max[0]
                    &&
                    double.Parse(item.longitude) >= geo.min[1]
                    &&
                    double.Parse(item.longitude) <= geo.max[1]
                    &&
                    Math.Acos(Math.Sin(Geolocation.ConvertToRadians(double.Parse(latitude))) * Math.Sin(Geolocation.ConvertToRadians(double.Parse(item.latitude))) + Math.Cos(Geolocation.ConvertToRadians(double.Parse(latitude))) * Math.Cos(Geolocation.ConvertToRadians(double.Parse(item.latitude))) * Math.Cos(Geolocation.ConvertToRadians(double.Parse(item.longitude)) - Geolocation.ConvertToRadians(double.Parse(longitude)))) <= double.Parse(range)/6371
                ).ToList();
            return stations;
        }
        [HttpGet]
        [Route("[controller/GetAll]")]
        public List<Stations> GetAll(string fuelType, string plugType)
        {
            List<Stations> stations = Context.Station.Where(
                item => 
                    item.plugs.Any(
                        _item=>_item.plugName==plugType && _item.fuel.fuelName==fuelType
                        )
                ).ToList();
            return stations;
        }


    }
}

