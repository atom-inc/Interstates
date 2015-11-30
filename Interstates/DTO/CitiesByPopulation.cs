using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class CitiesByPopulation : IWriteable
    {
        public int Population { get; set; }

        public List<CitiesByPopulationItem> Items { get; set; }

        public string GetStringToWrite()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(Population.ToString());

            foreach (var item in Items)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine(item.StateCity);
                stringBuilder.AppendLine(string.Format("Interstates: {0}", item.Interstates));
            }

            return stringBuilder.ToString();
        }
    }

    public class CitiesByPopulationItem
    {
        public string StateCity { get; set; }

        public string Interstates { get; set; }
    }
}
