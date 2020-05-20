using SebGlowDrive.Data.Model;
using System.Collections.Generic;

namespace SebGlowDrive.Data
{
    public class RoadRespository : IRoadRepository
    {
        private readonly ICollection<Road> roads;

        public RoadRespository()
        {
            this.roads = new List<Road>();
        }

        public void Add(Road newRoad)
        {
            roads.Add(newRoad);
        }

        public ICollection<Road> All()
        {
            return roads;
        }
    }
}
