using System;

namespace SmartPark.Models
{
    public class Spots
    {
        public string Id { get; set; }
        
        public string Name { get; set; }

        public string Type { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Value { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        public int BatteryStatus { get; set; }
    }
}