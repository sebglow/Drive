
namespace SebGlowDrive.Data.Model
{
    public class Road
    {
        public string Name { get; set; }
        public GeoLocation Start { get; set; }
        public GeoLocation End { get; set; }
        public Line RoadPattern { get; set; }
    }
}
