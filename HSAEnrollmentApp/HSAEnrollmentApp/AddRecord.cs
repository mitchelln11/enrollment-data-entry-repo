using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace HSAEnrollmentApp
{
    class AddRecord
    {
        //protected string fName;
        //protected string lName;
        //protected string dob;
        //protected string plan;
        //protected string effectiveDate;
        //protected string filepath = "../../files/hsa-enrolled.csv";

        //// Validators -------DO NOT ADD LEADING AND ENDING /, IT WILL NOT WORK IF YOU DO-------------
        //protected string regexBirthday = @"\b[0-1][1-9]((\/)?|(\-)?)[0-3][\d]((\/)?|(\-)?)[\d]{4}\b";
        CsvData enrolled = new CsvData();

        public string AddFirstName()
        {
            Console.WriteLine("Please Type in the client's first name. Then hit enter after.");
            enrolled.FirstName = Console.ReadLine();
            return enrolled.FirstName;
        }

        public string AddLastName()
        {
            Console.WriteLine("Please Type in the client's last name. Then hit enter after.");
            enrolled.LastName = Console.ReadLine();
            return enrolled.LastName;
        }

        public bool CalculateAge(string dob)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            int currentDay = DateTime.Now.Day;
            int minimumAge = 18;

            string[] clientBirthday = dob.Split('/');
            if (currentYear - Convert.ToInt32(clientBirthday[2]) == minimumAge)
            {
                if (Convert.ToInt32(clientBirthday[0]) == currentMonth )
                {
                    if (Convert.ToInt32(clientBirthday[1]) <= currentDay)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, this person must be at least {minimumAge} years of age", 0);
                    }
                }
                else if (Convert.ToInt32(clientBirthday[0]) < currentMonth)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Sorry, this person must be at least {minimumAge} years of age", 0);
                }
            }
            else if (currentYear - Convert.ToInt32(clientBirthday[2]) > minimumAge)
            {
                return true;
            }
            Console.WriteLine("Sorry, this person must be at least " + minimumAge + " years of age");
            Console.ReadLine();
            return false;
        }

        public string AddDob()
        {
            Console.WriteLine("\r\nPlease Type in the client's Date of Birth.\r\nFormat must be 01/02/2020. For single digits, please use a leading 0.\r\nThen hit enter after.");
            enrolled.DateOfBirth = Console.ReadLine();
            string dob = enrolled.DateOfBirth;

            Regex regex = new Regex(enrolled.RegexBirthday);
            Match match = regex.Match(dob);
            if ((match.Success) && (CalculateAge(dob) == true))
            {
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
            enrolled.PlanType = Console.ReadLine().ToUpper();
            return enrolled.PlanType;
        }

        public DateTime AddEffectiveDate()
        {
            var currentDay = DateTime.Now;
            enrolled.EffectiveDate = currentDay.ToString("MM/dd/yyyy");
            return Convert.ToDateTime(enrolled.EffectiveDate);
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
            AddNewRecord(enrolled.FirstName, enrolled.LastName, enrolled.DateOfBirth, enrolled.PlanType, enrolled.EffectiveDate, enrolled.FilePath);
        }
    }
}
