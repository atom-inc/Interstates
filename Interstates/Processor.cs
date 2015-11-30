using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class Processor
    {
        private IEnumerable<InputFileDataRow> inputData;

        private List<CitiesByPopulation> citiesByPopulation;

        private InterstatesByCity interstatesByCity;

        public List<CitiesByPopulation> CitiesByPopulation
        {
            get
            {
                if (citiesByPopulation == null)
                    return new List<CitiesByPopulation>();

                return citiesByPopulation;
            }
        }

        public InterstatesByCity InterstatesByCity
        {
            get
            {
                if (interstatesByCity == null)
                    return new InterstatesByCity();

                return interstatesByCity;
            }
        }

        public Processor(IEnumerable<InputFileDataRow> InputData)
        {
            inputData = InputData;

            citiesByPopulation = new List<CitiesByPopulation>();

            interstatesByCity = new InterstatesByCity
            {
                Items = new List<InterstatesByCityItem>()
            };

        }


        public void ConvertToInterstateByCities()
        {
            var interstates = GetAllInterstates();
            foreach(var interstate in interstates)
            {
                interstatesByCity.Items.Add(new InterstatesByCityItem
                {
                    Interstate = string.Format("I-{0}", interstate),
                    NumberOfCities = inputData.Count(c => c.Interstates.Contains(interstate))
                });
            }
        }

        private List<int> GetAllInterstates()
        {
            List<int> interstates = new List<int>();
            foreach (var row in inputData)
            {
                foreach (var interstateInRow in row.Interstates)
                {
                    if (interstates.Contains(interstateInRow))
                    {
                        continue;
                    }
                    interstates.Add(interstateInRow);
                }
            }
            return interstates;
        }



        public void ConvertToCitiesByPopulation()
        {
            foreach (var row in inputData)
            {
                if(citiesByPopulation.Exists(s => s.Population == row.Population))
                {
                    var item = citiesByPopulation.FirstOrDefault(f => f.Population == row.Population);
                    item.Items.Add(GetCitiesByPopulationItem(row));
                }
                else
                {
                    var items = new List<CitiesByPopulationItem>();
                    items.Add(GetCitiesByPopulationItem(row));
                    citiesByPopulation.Add(new CitiesByPopulation
                    {
                        Population = row.Population,
                        Items = items
                    });
                }
            }
        }

        private CitiesByPopulationItem GetCitiesByPopulationItem(InputFileDataRow inputFileDataRow)
        {
            return new CitiesByPopulationItem
            {
                Interstates = GetInterstates(inputFileDataRow.Interstates),
                StateCity = inputFileDataRow.City + ", " + inputFileDataRow.State
            };
        }

        private string GetInterstates(IEnumerable<int> interstates)
        {
            List<string> result = new List<string>();
            foreach (var interstate in interstates)
            {
                result.Add(string.Format("I-{0}", interstate));
            }
            return string.Join(", ", result);
        }

        

    }
}
