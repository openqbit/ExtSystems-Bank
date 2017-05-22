using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.Common.Models
{
    public class AccountTypes 
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public bool status { get; set; }

        //public String Saving { get; set; }
        //public String Deposit { get; set; }
        //public String Loan { get; set; }
        //public String Joint { get; set; }
        //public String Low_cost { get; set; }
        //public String Numbered { get; set; }

    }
}
