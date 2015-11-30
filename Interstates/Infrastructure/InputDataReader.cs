using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class InputDataReader
    {
        private FileInfo _inputFile;
        private List<InputFileDataRow> _data;

        private InputDataReader() { }

        public InputDataReader(FileInfo inputFile)
        {
            _inputFile = inputFile;
        }

        public IEnumerable<InputFileDataRow> GetData()
        {
            if (_data == null)
            {
                ReadDataFromFile();
            }
            return _data;
        }

        private void ReadDataFromFile()
        {
            _data = new List<InputFileDataRow>();
            if (_inputFile != null)
            {
                string[] fileRows = System.IO.File.ReadAllLines(_inputFile.FullName);
                foreach (string fileRow in fileRows)
                {
                    string[] splitedRow = fileRow.Split('|');
                    if (splitedRow.Length < 3)
                    {
                        throw new FormatException("Wrong file format");
                    }

                    int population;
                    if (!int.TryParse(splitedRow[0], out population))
                    {
                        throw new FormatException("First column must be a number.");
                    }

                    string city = splitedRow[1];
                    string state = splitedRow[2];

                    var interstates = new List<int>();
                    if (!string.IsNullOrEmpty(splitedRow[3]))
                    {
                        string[] splitedInterstates = splitedRow[3].Split(';');
                        foreach (var interstateText in splitedInterstates)
                        {
                            int interstateNumder;
                            if (int.TryParse(interstateText.Replace("I-", ""), out interstateNumder))
                            {
                                interstates.Add(interstateNumder);
                            }
                            else
                            {
                                throw new FormatException("Interstate must have format \"I-<interstate number>\".");
                            }
                        }
                    }

                    _data.Add(new InputFileDataRow(population, city, state, interstates));
                }
            }
        }
    }
}
