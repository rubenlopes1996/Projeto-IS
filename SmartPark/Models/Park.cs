﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartPark.Models
{
    public class Park
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Spots> spots { get; set; }
    }
}