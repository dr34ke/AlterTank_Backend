using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class Prices
    {
        public Guid id { get; set; }
        public DateTime date { get; set; }
        public float price { get; set; }
        public Fuels fuel { get; set; }
        public int fuelId { get; set; }
        public Stations Station { get; set; }
        public Guid stationId { get; set; }
    }
}
