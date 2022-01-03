using AlterTankBackend.Database;
using AlterTankBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Controllers
{
    public class StationsController: ControllerBase 
    {
        readonly DBContext Context;
        public StationsController(DBContext dBContext)
            => Context = dBContext;

        [HttpGet]
        [Route("[controller]/GetInRange")]
        public List<Stations> GetInRange(string latitude, string longitude, string range, string plugType)
        {
            Geolocation geo = Geolocation.BoundingCoordinates(double.Parse(range), double.Parse(latitude), double.Parse(longitude));

            List<Stations> stations = Context.Station.Where(
                    item =>
                    item.plugStations.Any(_item => _item.Plug.id.ToString() == plugType)
                    && 
                    double.Parse(item.latitude) >= geo.min[0]
                    &&
                    double.Parse(item.latitude) <= geo.max[0]
                    &&
                    double.Parse(item.longitude) >= geo.min[1]
                    &&
                    double.Parse(item.longitude) <= geo.max[1]
                    &&
                    Math.Acos(Math.Sin(Geolocation.ConvertToRadians(double.Parse(latitude))) * Math.Sin(Geolocation.ConvertToRadians(double.Parse(item.latitude))) + Math.Cos(Geolocation.ConvertToRadians(double.Parse(latitude))) * Math.Cos(Geolocation.ConvertToRadians(double.Parse(item.latitude))) * Math.Cos(Geolocation.ConvertToRadians(double.Parse(item.longitude)) - Geolocation.ConvertToRadians(double.Parse(longitude)))) <= double.Parse(range) / 6371
                ).ToList();
            return stations;
            return new List<Stations>();
        }
        [HttpGet]
        [Route("[controller]/GetAll")]
        public List<Stations> GetAll(string plugType)
        {
            List<Stations> stations = Context.Station.Where(
                item =>
                    item.plugStations.Any(
                        _item => _item.Plug.id.ToString() == plugType
                        )
                ).ToList();
            return stations; 
            return new List<Stations>();
        }
        [HttpPut]
        [Route("[controller]/AddNewStation")]
        public IActionResult AddNewStation(Stations stations)
        {
            Context.Add<Stations>(stations);
            Context.SaveChanges();
            return Ok(stations.id);
        }
        [HttpPut]
        [Route("[controller]/AddPlug")]
        public IActionResult AddNewPlug(string StationId, string PlugId, string Count)
        {
            var result = Context.PlugsStations.SingleOrDefault(s => s.StationId.ToString() == StationId && s.PlugId.ToString()==PlugId);
            if (result != null)
            {
                result.Count = Int32.Parse(Count);
            }
            else 
            {
                PlugsStations plugsStations = new PlugsStations()
                {
                    PlugId = Int32.Parse(PlugId),
                    StationId = Guid.Parse(StationId),
                    Count = Int32.Parse(Count)
                };
                Context.PlugsStations.Add(plugsStations);
            }
            Context.SaveChanges();
            return Ok();
        }




    }
}

