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

        public List<int> Interstates { get; set; }
    }
}
