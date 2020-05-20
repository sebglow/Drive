using System;
using SebGlowDrive.Data.Model;

namespace SebGlowDrive.Services
{
    public class MathService : IMathService
    {
        //public Func<GeoLocation, Line, double> CalculateDistance => calculateDistance;

        public Func<GeoLocation, Func<Line, GeoLocation, double>> CalculateDistance { get; }

        public MathService()
        {
            CalculateDistance = point => (line, start) => calculateDistance(point, line, start);
        }

        public Line CalculateLine(double x1, double y1, double x2, double y2)
        {
            //y = mx + d
            var m = calculateSlope(x1, y1, x2, y2);
            if (m == null)
            {
                return null;
            }

            var d = y1 - m * x1;

            //convert to: ax + by + c = 0 
            var a = -1d * m;
            var b = 1d;
            var c = -1d * d;

            return new Line(a, b, c);
        }

        private double? calculateSlope(double x1, double y1, double x2, double y2)
        {
            if (x2 == x1) //vertical line
            {
                return null;
            }

            return (y2 - y1) / (x2 - x1);
        }

        private double calculateDistance(GeoLocation p, Line l, GeoLocation s)
        {
            double distance = 0d;
            if (l != null)
            {
                distance =
                    Math.Abs(l.A.Value * p.X + l.B * p.Y + l.C.Value) /
                    Math.Sqrt(Math.Pow(l.A.Value, 2) + Math.Pow(l.B, 2));
            }
            else
            {
                distance = Math.Abs(p.X - s.X);
            }
            return distance;
        }
    }
}
