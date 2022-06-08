using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndianStateCensusAnalyser.POCO;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;


namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        public enum Country
        {
            INDIA
        }
        public Dictionary<string, CensusDTO> dataMap;
        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
        public void ReadCsvFile()
        {
            string csvPath = @"C:\Users\Admin\Desktop\Vishnu\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };
            int count = 0;
            using var streamReader = File.OpenText(csvPath);
            using var csvReader = new CsvReader(streamReader, csvConfig);
            string value;
            int row = 0;
            while (csvReader.Read())
            {
                for (int i = 0; csvReader.TryGetField<string>(i, out value); i++)
                {
                    count++;
                    //Console.Write($"{value} ");
                }
                //Console.WriteLine();
                row++;
            }
            Console.WriteLine(row);
        }
    }
    public class DataHeadersClass
    {
        public string State;
        public string Population;
        public string AreaInSqKm;
        public string DensityPerSqKm;
    }
}

