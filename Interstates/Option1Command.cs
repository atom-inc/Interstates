using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interstates
{
    public class Option1Command : ICommand
    {
        private FileInfo _inputFileInfo;
        private IEnumerable<InputFileDataRow> _inputData;
        private IEnumerable<CitiesByPopulation> _citiesByPopulationData;
        private IEnumerable<InterstatesByCity> _interstatesByCityData;

        public void Execute(string filename)
        {
            CheckInputFile(filename);
            ReadInputFile();
            //Process data
            WriteOutputFiles();
        }

        private void CheckInputFile(string filename)
        {
            _inputFileInfo = new FileInfo(filename);
            if (!_inputFileInfo.Exists)
            {
                throw new Exception("File not found.");
            }
        }

        private void ReadInputFile()
        {
            var dataReader = new InputDataReader(_inputFileInfo);
            _inputData = dataReader.GetData();
        }

        private void WriteOutputFiles()
        {
            WriteCitiesByPopulationFile();
            WriteInterstatesByCityFile();
        }

        private void WriteInterstatesByCityFile()
        {
            var dataWriter = new OutputDataWriter();
            dataWriter.Write("Interstates_By_City.txt", _interstatesByCityData);
        }

        private void WriteCitiesByPopulationFile()
        {
            var dataWriter = new OutputDataWriter();
            dataWriter.Write("Cities_By_Population.txt", _citiesByPopulationData);
        }
    }
}
