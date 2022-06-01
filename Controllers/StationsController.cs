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
        public List<StationsWithPrice> GetInRange(string latitude, string longitude, string range, string plugType)
        {
            latitude=latitude.Replace(".", ",");
            longitude=longitude.Replace(".", ",");
            range = range.Replace(".", ",");
            Geolocation geo = Geolocation.BoundingCoordinates(double.Parse(range), double.Parse(latitude), double.Parse(longitude));     
            List<Stations> stations = Context.Station.Where(
                    item =>
                    item.plugStations.Any(_item => _item.Plug.id.ToString() == plugType)&&
                    item.latitude >= geo.min[0]&&item.latitude <= geo.max[0]&&item.longitude >= geo.min[1]&&item.longitude <= geo.max[1]&&
                    Math.Acos(
                        Math.Sin(geo.radianLat) * Math.Sin(item.latitude) + Math.Cos(geo.radianLat) * Math.Cos(item.latitude) * Math.Cos(item.longitude - geo.radianLong)
                        ) <= (double.Parse(range) / 6371)
                ).ToList();
            Plugs plug = Context.Plugs.Where(_item => _item.id == Int32.Parse(plugType)).FirstOrDefault();
            List<StationsWithPrice> _stations = new List<StationsWithPrice>(); 
            foreach (Stations stations1 in stations)
            {
                var lastPrice = Context.Prices.Where(
                    _item => _item.fuelId == plug.fuelId && _item.stationId == stations1.id
                    ).OrderByDescending(item => item.date).FirstOrDefault();
                if (lastPrice != null)
                {
                    StationsWithPrice stationsWithPrice = new StationsWithPrice(stations1, lastPrice.price.ToString());
                    _stations.Add(stationsWithPrice);
                }
                else {
                    StationsWithPrice stationsWithPrice = new StationsWithPrice(stations1);
                    _stations.Add(stationsWithPrice);
                }
            }
            return _stations;
        }
        [HttpGet]
        [Route("[controller]/GetAll")]
        public List<StationsWithPrice> GetAll(string plugType)
        {
            List<Stations> stations = Context.Station.Where(
                item =>
                    item.plugStations.Any(
                        _item => _item.Plug.id.ToString() == plugType
                        )
                ).ToList();
            Plugs plug = Context.Plugs.Where(_item => _item.id == Int32.Parse(plugType)).FirstOrDefault();
            List<StationsWithPrice> _stations = new List<StationsWithPrice>();
            foreach (Stations stations1 in stations)
            {
                var lastPrice = Context.Prices.Where(_item => _item.fuelId == plug.fuelId && _item.stationId == stations1.id).OrderByDescending(item => item.date).FirstOrDefault();
                if (lastPrice != null)
                {
                    StationsWithPrice stationsWithPrice = new StationsWithPrice(stations1, lastPrice.price.ToString());
                    _stations.Add(stationsWithPrice);
                }
                else
                {
                    StationsWithPrice stationsWithPrice = new StationsWithPrice(stations1);
                    _stations.Add(stationsWithPrice);
                }
            }
            return _stations; 
        }
        [HttpPut]
        [Route("[controller]/AddNewStation")]
        public IActionResult AddNewStation(Stations stations)
        {
            Context.Add<Stations>(stations);
            stations.latitude = Geolocation.ConvertToRadians(stations.latitude);
            stations.longitude = Geolocation.ConvertToRadians(stations.longitude);
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


        [HttpPut]
        [Route("[controller]/AddPrice")]
        public IActionResult AddPrice(Guid StationId, int FuelId, float PricePerUnit, DateTime Date)
        {
            Prices price = new Prices(){ 
                date=Date,
                fuelId=FuelId,
                price=PricePerUnit,
                stationId=StationId,
            };

            Context.Prices.Add(price);
            Context.SaveChanges();
            return Ok();
        }



    }
}

