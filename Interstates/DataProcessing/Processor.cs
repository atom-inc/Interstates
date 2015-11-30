using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class Processor
    {
        private IEnumerable<InputFileDataRow> _inputData;
        private List<CitiesByPopulation> _citiesByPopulation;
        private InterstatesByCity _interstatesByCity;

        public List<CitiesByPopulation> CitiesByPopulation
        {
            get
            {
                if (_citiesByPopulation == null)
                    ConvertToCitiesByPopulation();

                return _citiesByPopulation;
            }
        }

        public InterstatesByCity InterstatesByCity
        {
            get
            {
                if (_interstatesByCity == null)
                    ConvertToInterstateByCities();

                return _interstatesByCity;
            }
        }

        public Processor(IEnumerable<InputFileDataRow> inputData)
        {
            _inputData = inputData;
        }

        private void ConvertToInterstateByCities()
        {
            _interstatesByCity = new InterstatesByCity();
            var interstates = GetAllInterstates();
            foreach (var interstate in interstates.OrderByDescending(i => i))
            {
                _interstatesByCity.Items.Add(new InterstatesByCityItem
                {
                    Interstate = string.Format("I-{0}", interstate),
                    NumberOfCities = _inputData.Count(c => c.Interstates.Contains(interstate))
                });
            }
        }

        private List<int> GetAllInterstates()
        {
            List<int> interstates = new List<int>();
            foreach (var row in _inputData)
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

        private void ConvertToCitiesByPopulation()
        {
            _citiesByPopulation = new List<CitiesByPopulation>();
            foreach (var row in _inputData)
            {
                if (_citiesByPopulation.Exists(s => s.Population == row.Population))
                {
                    var item = _citiesByPopulation.FirstOrDefault(f => f.Population == row.Population);
                    item.Items.Add(GetCitiesByPopulationItem(row));
                }
                else
                {
                    var items = new List<CitiesByPopulationItem>();
                    items.Add(GetCitiesByPopulationItem(row));
                    _citiesByPopulation.Add(new CitiesByPopulation
                    {
                        Population = row.Population,
                        Items = items
                    });
                }

                _citiesByPopulation = _citiesByPopulation.OrderByDescending(c => c.Population).ToList();
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
            foreach (var interstate in interstates.OrderBy(i => i))
            {
                result.Add(string.Format("I-{0}", interstate));
            }
            return string.Join(", ", result);
        }
    }
}
