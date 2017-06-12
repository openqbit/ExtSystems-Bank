using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


using OpenQbit.ExternalBank.Common.Models;
using OpenQbit.ExternalBank.DAL.Contracts;

namespace OpenQbit.ExternalBank.DAL
{
   public class ExternalBankContext : DbContext 
    {
        public ExternalBankContext() : base("ExternalBankDB")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Account> Account { get; set; }

        public DbSet<AccountTypes> AccountTypes { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<TransactionDetail> TransactionDetail { get; set; }

        public DbSet<TransactionType> TransactionType { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
