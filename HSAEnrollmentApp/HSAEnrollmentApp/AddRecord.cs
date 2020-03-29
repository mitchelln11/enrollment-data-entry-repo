using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HSAEnrollmentApp
{
    class AddRecord
    {
        public string fName;
        protected string lName;
        protected DateTime dob;
        protected string plan;
        protected string effectiveDate;
        protected string filepath = "../../files/hsa-enrolled.csv";

        public string AddFirstName()
        {
            Console.WriteLine("Please Type in the client's first name. Then hit enter after.");
            fName = Console.ReadLine();
            return fName;
        }

        public string AddLastName()
        {
            Console.WriteLine("Please Type in the client's last name. Then hit enter after.");
            lName = Console.ReadLine();
            return lName;
        }

        public DateTime AddDob()
        {
            Console.WriteLine("\r\nPlease Type in the client's Date of Birth.\r\nFormat must be 01/02/2020. For single digits, please use a leading 0.\r\nThen hit enter after.");

            if (DateTime.TryParse(Console.ReadLine(), out dob))
            {
                return dob;
            }
            else
            {
                Console.WriteLine("I'm sorry, the format was incorrect. Please try again.");
            }
            Console.ReadLine();
            return dob;
        }

        public string AddPlanType()
        {
            Console.WriteLine("\r\nPlease Type in the client's Plan.\r\nYour options are HSA, HRA, and FSA.\r\nThen hit enter after.");
            plan = Console.ReadLine();
            return plan;
        }

        public DateTime AddEffectiveDate()
        {
            var currentDay = DateTime.Now;
            effectiveDate = currentDay.ToString("MM/dd/yyyy");
            return Convert.ToDateTime(effectiveDate);
        }

        public void AddNewRecord(string fName, string lName, DateTime dob, string plan, string effectiveDate, string filepath)
        {
            try
            {
                using(StreamWriter file = new StreamWriter(@filepath, true))
                {
                    file.WriteLine(fName + "," + lName + "," + dob + "," + plan + "," + effectiveDate);
                    
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("There was a problem adding the new record:", ex);
            }
        }

        public void RunAllRecordOptions()
        {
            AddFirstName();
            AddLastName();
            AddDob();
            AddPlanType();
            AddEffectiveDate();
            AddNewRecord(fName, lName, dob, plan, effectiveDate, filepath);
        }
    }
}
