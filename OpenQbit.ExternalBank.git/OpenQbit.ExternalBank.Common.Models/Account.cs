using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.Common.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int BankAccNo { get; set; }
        public int CurrentBalance { get; set; }
        public int AccountTypesId { get; set;}
        public virtual AccountTypes AccountTypes { get; set;}

        




    }
}
