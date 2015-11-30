using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class InputFileDataRow
    {
        public int Population { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public IEnumerable<int> Interstates { get; set; }

        public InputFileDataRow(int population, string city, string state, IEnumerable<int> interstates)
        {
            Population = population;
            City = city;
            State = state;
            Interstates = interstates;
        }
    }
}
