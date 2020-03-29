using System;
using System.IO;
using System.Text.RegularExpressions;

namespace HSAEnrollmentApp
{
    class AddRecord
    {
        protected string fName;
        protected string lName;
        protected string dob;
        protected string plan;
        protected string effectiveDate;
        protected string filepath = "../../files/hsa-enrolled.csv";

        // Validators
        protected string regexBirthday = @"^[0-1][1-9]((\/)?|(\-)?)[0-3][\d]((\/)?|(\-)?)[\d]{4}$";

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

        public string AddDob()
        {
            Console.WriteLine("\r\nPlease Type in the client's Date of Birth.\r\nFormat must be 01/02/2020. For single digits, please use a leading 0.\r\nThen hit enter after.");
            dob = Console.ReadLine();

            Regex regex = new Regex(regexBirthday);
            Match match = regex.Match(dob);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
                return dob;
            }
            else
            {
                Console.WriteLine("I'm sorry, the format was incorrect. Please try again.");
                Console.ReadLine();
                AddDob();
            }
            return null;
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

        public void AddNewRecord(string fName, string lName, string dob, string plan, string effectiveDate, string filepath)
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
