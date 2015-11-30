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
        private InterstatesByCity _interstatesByCityData;

        public void Execute(string filename)
        {
            CheckInputFile(filename);
            ReadInputFile();
            ProcessData();
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

        private void ProcessData()
        {
            var dataProcessor = new Processor(_inputData);
            _citiesByPopulationData = dataProcessor.CitiesByPopulation;
            _interstatesByCityData = dataProcessor.InterstatesByCity;
        }

        private void WriteOutputFiles()
        {
            WriteCitiesByPopulationFile();
            WriteInterstatesByCityFile();
        }

        private void WriteInterstatesByCityFile()
        {
            var dataWriter = new OutputDataWriter();
            dataWriter.Write("Interstates_By_City.txt", _interstatesByCityData.Items);
        }

        private void WriteCitiesByPopulationFile()
        {
            var dataWriter = new OutputDataWriter();
            dataWriter.Write("Cities_By_Population.txt", _citiesByPopulationData);
        }
    }
}
