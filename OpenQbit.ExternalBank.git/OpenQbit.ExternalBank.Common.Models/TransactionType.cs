using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.Common.Models
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public bool status { get; set; }
        //public int Charge { get; set; }
        //public int Check { get; set; }
        //public int Online { get; set; }
        //public int POS { get; set; }
        //public int Transfer { get; set; }


    }
}
