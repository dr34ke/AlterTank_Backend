using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlterTankBackend.Models
{
    public class Geolocation
    {
        public double radianLat;
        public double radianLong;
        private double r;

        private static double _MIN_LAT = Geolocation.ConvertToRadians(-90d);  // -PI/2
        private static double _MAX_LAT = Geolocation.ConvertToRadians(90d);   //  PI/2
        private static double _MIN_LON = Geolocation.ConvertToRadians(-180d); // -PI
        private static double _MAX_LON = Geolocation.ConvertToRadians(180d);  //  PI

        private double MIN_LAT;
        private double MAX_LAT;
        private double MIN_LON;
        private double MAX_LON;

        public double[] min;
        public double[] max;

        private const double earthRadius = 6371;

        public Geolocation(){

        }

        public static double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }
        public static double ConvertToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return degrees;
        }
        public static Geolocation BoundingCoordinates(double distance, double latitude, double longitude)
        {
            
            Geolocation geo = new Geolocation();
            geo.r = distance / Geolocation.earthRadius;
            geo.radianLat = Geolocation.ConvertToRadians(latitude);
            geo.radianLong = Geolocation.ConvertToRadians(longitude);


            geo.MIN_LAT = geo.radianLat - geo.r;
            geo.MAX_LAT = geo.radianLat + geo.r;


            if(geo.MIN_LAT >_MIN_LAT && geo.MAX_LAT < _MAX_LAT)
            {
                double deltaLon = Math.Asin(Math.Sin(geo.r) /
                    Math.Cos(geo.radianLat));
                geo.MIN_LON = geo.radianLong - deltaLon;
                if (geo.MIN_LON < _MIN_LON) geo.MIN_LON += 2d * Math.PI;
                geo.MAX_LON = geo.radianLong + deltaLon;
                if (geo.MAX_LON > _MAX_LON) geo.MAX_LON -= 2d * Math.PI;
            }
            else
            {  
                geo.MIN_LAT = Math.Max(geo.MIN_LAT, _MIN_LAT);
                geo.MAX_LAT = Math.Min(geo.MAX_LAT, _MAX_LAT);
                geo.MIN_LON = _MIN_LON;
                geo.MAX_LON = _MAX_LON;
            }
            geo.min = new double[2] {geo.MIN_LAT, geo.MIN_LON };
            geo.max = new double[2] { geo.MAX_LAT, geo.MAX_LON };
           
            return geo;
        }
        public override string ToString()
        {
            return this.min[0].ToString()+" "+this.min[1].ToString()+ " " + this.max[0].ToString()+" "+ this.max[1].ToString();
        }
    }
}
