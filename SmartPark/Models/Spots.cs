﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class Spots
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Type { get; set; }
        
        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Value { get; set; }
        
        public DateTime Timestamp { get; set; }
        
        public int BatteryStatus { get; set; }
    }
}