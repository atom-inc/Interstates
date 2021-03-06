﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class InterstatesByCity
    {
        public List<InterstatesByCityItem> Items { get; set; }

        public InterstatesByCity()
        {
            Items = new List<InterstatesByCityItem>();
        }
    }

    public class InterstatesByCityItem : IWriteable
    {
        public string Interstate { get; set; }

        public int NumberOfCities { get; set; }

        public string GetStringToWrite()
        {
            return string.Format("{0} {1}", Interstate, NumberOfCities);
        }
    }
}
