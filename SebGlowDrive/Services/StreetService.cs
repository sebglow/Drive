using SebGlowDrive.Data;
using SebGlowDrive.Data.Model;
using SebGlowDrive.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SebGlowDrive.Services
{
    public class StreetService : IStreetService
    {
        private IRoadRepository roadRepository;
        private IMathService mathService;

        public StreetService(
            IRoadRepository roadRepository,
            IMathService mathService)
        {
            this.roadRepository = roadRepository;
            this.mathService = mathService;
        }

        public void AddStreet(Street s)
        {
            var x1 = s.start[0];
            var y1 = s.start[1];
            var x2 = s.end[0];
            var y2 = s.end[1];

            var line = mathService.CalculateLine(x1, y1, x2, y2);

            var newRoad = new Road
            {
                Name = s.name,
                Start = new GeoLocation(x1, y1),
                End = new GeoLocation(x2, y2),
                RoadPattern = line
            };

            this.roadRepository.Add(newRoad);
        }

        public IEnumerable<Street> FindNearest(double x, double y)
        {
            var point = new GeoLocation(x, y);

            var roadsWithDistance = this.roadRepository.All()
                .Select(r => new
                {
                    road = r,
                    distance = mathService.CalculateDistance(point)(r.RoadPattern, r.Start)
                });

            if (roadsWithDistance.Count() == 0)
                return null;

            var minDistance = roadsWithDistance.Min(r => r.distance);

            return roadsWithDistance.Where(r => r.distance == minDistance)
                        .Select(r => new Street
                        {
                            name = r.road.Name,
                            start = new double[] { r.road.Start.X, r.road.Start.Y },
                            end = new double[] { r.road.End.X, r.road.End.Y }
                        });
        }

        public IEnumerable<Street> GetAll()
        {
            var allRoads = roadRepository.All();

            return allRoads.Select(r => new Street()
            {
                name = r.Name,
                start = new double[] { r.Start.X, r.Start.Y },
                end = new double[] { r.End.X, r.End.Y }
            }).AsEnumerable();
        }
    }
}
