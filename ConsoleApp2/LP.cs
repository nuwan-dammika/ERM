using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class LP:BaseEnergy
    {

        [Name ("Data Value")]
        public double DataValue { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }

       
    }
}
