using System;
using System.Linq;
using System.IO;

namespace HSAEnrollmentApp
{
    class ReadFile
    {
        public void ReadCsvFile()
        {
            var enrolledData = File.ReadAllLines(@"..\..\files\hsa-enrolled.csv");

            var enrollList = from enrolledInfo in enrolledData
            let data = enrolledInfo.Split(',')
            select new
            {
                FirstName = data[0],
                LastName = data[1],
                DoB = data[2],
                PlanType = data[3],
                EffectiveDate = data[4]
            };

            foreach (var client in enrollList)
            {
                Console.WriteLine(client.FirstName + "|" + client.LastName + "|" + client.DoB + "|" + client.PlanType + "|" + client.EffectiveDate);
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
