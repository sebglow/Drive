using System.Collections.Generic;

using SebGlowDrive.Model;

namespace SebGlowDrive.Services
{
    public interface IStreetService
    {
        IEnumerable<Street> FindNearest(double x, double y);

        void AddStreet(Street s);

        IEnumerable<Street> GetAll();
    }
}