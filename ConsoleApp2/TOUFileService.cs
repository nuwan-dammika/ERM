using CsvHelper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading;
namespace ConsoleApp2
{
    public class TOUFileService : IFileService
    { private readonly ILogger<TOUFileService> _logger;
        public TOUFileService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TOUFileService>();
        }

        public Tuple<List<BaseEnergy>, double> FindMedien(string fileName)
        {
            var reader = new StreamReader(fileName);
            var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var allRecords = csvReader.GetRecords<TOU>().ToList();
            var median = Double.MinValue;
            //read csv file
            if (allRecords.Count % 2 != 0)
            {
                var celNo = Math.Round(Convert.ToDouble(allRecords.Count / 2)+0.40) - 1;
                median = allRecords.OrderBy(a => a.Energy).ToList()[Convert.ToInt32(celNo)].Energy;
            }              
            else
            {                 
                var med1=allRecords.OrderBy(a => a.Energy).ToList()[(allRecords.Count / 2) - 1].Energy;
                var med2 = allRecords.OrderBy(a => a.Energy).ToList()[(allRecords.Count / 2) ].Energy;
                median = (med1 + med2) / 2;
            }
            
            var rowstoshow=  allRecords.Where(a => (((a.Energy * median) / 100) > 20) || (((a.Energy * median) / 100) < 20)  ).ToList();

            return new Tuple<List<BaseEnergy>, double>(rowstoshow.Cast<BaseEnergy>().ToList(), median);

        }
    }
}
