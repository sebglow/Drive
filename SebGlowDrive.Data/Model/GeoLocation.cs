using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SebGlowDrive.Data.Model
{
    public class GeoLocation
    {
        public double X { get; set; }
        public double Y { get; set; }

        public GeoLocation(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
