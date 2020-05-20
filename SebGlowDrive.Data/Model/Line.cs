using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SebGlowDrive.Data.Model
{
    public class Line
    {
        public double? A { get; }
        public double B { get; }
        public double? C { get; }
        
        public Line(double? a, double b, double? c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
