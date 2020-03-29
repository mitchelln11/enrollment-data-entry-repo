using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HSAEnrollmentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile readFile = new ReadFile();
            readFile.ReadCsvFile();

            AddRecord record = new AddRecord();
            record.RunAllRecordOptions();
        }
    }
}
