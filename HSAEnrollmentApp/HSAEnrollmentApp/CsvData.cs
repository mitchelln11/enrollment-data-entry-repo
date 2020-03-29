using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HSAEnrollmentApp
{
    class CsvData
    {
        // Fields
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string planType;
        private string effectiveDate;
        private string filePath = "../../files/hsa-enrolled.csv";
        private string regexBirthday = @"\b[0-1][1-9]((\/)?|(\-)?)[0-3][\d]((\/)?|(\-)?)[\d]{4}\b";

        // Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public string PlanType { get; set; }

        public string EffectiveDate { get; set; }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string RegexBirthday
        {
            get { return regexBirthday; }
            set { regexBirthday = value; }
        }

    }
}
