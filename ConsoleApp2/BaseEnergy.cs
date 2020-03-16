using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public abstract  class BaseEnergy
    {
        [Name("MeterPoint Code")]
        public double MeterPoint { get; set; }
        [Name("Serial Number")]
        public double SNnumber { get; set; }
        [Name("Plant Code")]
        public string PlantCode { get; set; }
        [Name("Date/Time")]
        public string DateTime { get; set; }
        [Name("Data Type")]
        public string DataType { get; set; }

        
    }
}
