using SebGlowDrive.Data.Model;
using System.Collections.Generic;

namespace SebGlowDrive.Data
{
    public interface IRoadRepository
    {
        void Add(Road newRoad);

        ICollection<Road> All();
    }
}