using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenQbit.ExternalBank.Common.Models
{
     public class Transaction
    {
        public String Id { set; get; }
        public DateTime TransactionDate { get; set; }
        public int Amount { get; set; }
        public int AccountNo { get; set; }

        public int TransactionTypeId { get; set; }
        public virtual TransactionType TransactionType { get; set;}


    }
}
