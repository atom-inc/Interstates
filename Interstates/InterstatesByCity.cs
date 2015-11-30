using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class InterstatesByCity
    {
        public List<InterstatesByCityItem> Items { get; set; }
    }

    public class InterstatesByCityItem
    {
        public string Interstate { get; set; }

        public int NumberOfCities { get; set; }
    }
}
