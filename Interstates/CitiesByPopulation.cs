using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class CitiesByPopulation
    {
        public int Population { get; set; }

        public List<CitiesByPopulationItem> Items { get; set; }
    }

    public class CitiesByPopulationItem 
    {
        public string StateCity {get; set;}

        public string Interstates {get; set;}
    }
}
