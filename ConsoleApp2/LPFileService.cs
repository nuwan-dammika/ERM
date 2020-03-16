using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
namespace ConsoleApp2
{
    public class LPFileService : IFileService
    { private readonly ILogger<LPFileService> _logger;
        public LPFileService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LPFileService>();
        }

        public Tuple<List<BaseEnergy>,double> FindMedien(string fileName)
        {
            var reader = new StreamReader(fileName);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var allRecords = csvReader.GetRecords<LP>().ToList();
            var median = Double.MinValue;
            //read csv file
            if (allRecords.Count % 2 != 0)
            {
                var celNo = Math.Round(Convert.ToDouble(allRecords.Count / 2) + 0.40) - 1;
                median = allRecords.OrderBy(a => a.DataValue).ToList()[Convert.ToInt32(celNo)].DataValue;
            }
            else
            {
                var med1 = allRecords.OrderBy(a => a.DataValue).ToList()[(allRecords.Count / 2) - 1].DataValue;
                var med2 = allRecords.OrderBy(a => a.DataValue).ToList()[(allRecords.Count / 2)].DataValue;
                median = (med1 + med2) / 2;
            }

            var rowstoshow = allRecords.Where(a => (((a.DataValue * median) / 100) > 20) || (((a.DataValue * median) / 100) < 20)).ToList();
             
           
            return new Tuple<List<BaseEnergy>, double>(rowstoshow.Cast<BaseEnergy>().ToList(),median);



        }
 
    }
}
