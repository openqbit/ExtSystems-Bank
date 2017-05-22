using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.Common.Models
{
    class TransactionDetail
    {
        
        public int Id { set; get; }
        public int TransactionId { get; set; }  //transation -->fk
        public int AccountId { get; set; }
        public double Amount { set; get;}
        public string Description { get; set; }
        public virtual Account Account { set; get;}
    }
}
