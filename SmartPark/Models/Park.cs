using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class Park
    {
        public int NumberOfSpots { get; set; }

        public int NumberOfSpecialSpots { get; set; }

        public string operationHours { get; set; }

        public string Name { get; set; }

    }
}