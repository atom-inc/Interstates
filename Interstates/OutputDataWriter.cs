using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class OutputDataWriter
    {
        public void Write(string filename, IEnumerable<IWriteable> source)
        {
            var writingData = new List<string>();
            foreach (var sourceItem in source)
            {
                writingData.Add(sourceItem.GetStringToWrite());
            }

            System.IO.File.WriteAllLines(filename, writingData);
        }
    }
}
