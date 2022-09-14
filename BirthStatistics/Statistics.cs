using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BirthStatistics
{
    class Statistics
    {
        private List<string> _dataSetSex = new List<string>();

        private List<Double> _dataSetSizes = new List<double>();

        private List<Double> _dataSetPercentages = new List<double>();

        readonly string NameInputDataSet;

        readonly string NameOutputDataSetSizes;

        readonly string NameOutputDataSetPercentages;

        private string _fileHeader = "";

        private double percentage = 0;

        private double countGender = 0.0;

        private const string PATHTEMPLATE = @"..\..\DataSet\";

        public Statistics(string nameInputDataSet, string nameOutputDataSetSizes,
                          string nameOutputDataSetPercentages)
        {
            NameInputDataSet = nameInputDataSet;
            NameOutputDataSetSizes = nameOutputDataSetSizes;
            NameOutputDataSetPercentages = nameOutputDataSetPercentages;
        }

        public string[] GetDataSetSex()
        {
            using (StreamReader sr = new StreamReader(PATHTEMPLATE + NameInputDataSet))
            {
                string line;

                _fileHeader = sr.ReadLine();
                
                while ((line = sr.ReadLine()) != null)
                {
                    _dataSetSex.Add(ParseCVSLine(line, ','));
                }
            }

            return _dataSetSex.ToArray();
        }

        private string ParseCVSLine(string line, char separator)
        {
            string[] parseLine = line.Split(separator);

            return parseLine[1];
        }

        public void CreatingDataSetsForGraph()
        {
            string[] dataSetSex = GetDataSetSex();

            for (int i = 1; i < dataSetSex.Length; i += 2)
            {
                countGender = 0;
                percentage = 0;

                for (int j = 0; j < i; j++)
                {
                    if (_dataSetSex[j] == "f")
                    {
                        countGender++;
                    }
                }

                percentage = (countGender / i) * 100;
                Console.WriteLine($"%: {percentage} for dataset size: {i}");

                _dataSetSizes.Add(i);
                _dataSetPercentages.Add(percentage);
            }

            Serializer.SaveToFile(NameOutputDataSetSizes, _dataSetSizes.ToArray(), PATHTEMPLATE);
            Serializer.SaveToFile(NameOutputDataSetPercentages, _dataSetPercentages.ToArray(), PATHTEMPLATE);
        }
    }
}
