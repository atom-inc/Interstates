using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class InterstatesByCity : IWriteable
    {
        public List<InterstatesByCityItem> Items { get; set; }

        public string GetStringToWrite()
        {
            var stringBuilder = new StringBuilder();
            foreach (var item in Items)
            {
                stringBuilder.AppendLine(string.Format("{0} {1}", item.Interstate, item.NumberOfCities));
            }

            return stringBuilder.ToString();
        }
    }

    public class InterstatesByCityItem
    {
        public string Interstate { get; set; }

        public int NumberOfCities { get; set; }
    }
}
