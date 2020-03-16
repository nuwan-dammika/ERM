using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class TOU : BaseEnergy 
    {
        public double Energy { get; set; }
        public double MaxDemand { get; set; }
        public string TimeOfMaxDemand { get; set; }
        public string Units { get; set; }
        public string Status { get; set; }
        public string Period { get; set; }
        public string DLSActive { get; set; }
        public string BillingResetCount { get; set; }

        public DateTime BillingResetCountTime { get; set; }
        public string Rate { get; set; }


        
    }
}
