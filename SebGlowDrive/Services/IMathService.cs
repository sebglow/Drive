using SebGlowDrive.Data.Model;
using System;

namespace SebGlowDrive.Services
{
    public interface IMathService
    {
        Line CalculateLine(double x1, double y1, double x2, double y2);

        Func<GeoLocation, Func<Line, GeoLocation, double>> CalculateDistance { get; }
    }
}