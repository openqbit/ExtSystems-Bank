using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.DAL.Contracts
{
    public class Class1
    {
        public int Id { get; set; }
        public int BankAccNo { get; set; }
        public int CurrentBalance { get; set; }
        public int AccountTypesId { get; set;}
        public virtual AccountTypes AccountTypes { get; set;}

        




    }
}
