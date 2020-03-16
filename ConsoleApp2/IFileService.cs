using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    interface IFileService
    {
        Tuple<List<BaseEnergy>,double> FindMedien(string fileName);
    }
}
