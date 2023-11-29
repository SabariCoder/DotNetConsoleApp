using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Transaction
    {
        public decimal amount { get; }
        public DateTime date { get; }
        public string note { get; }


        public Transaction(decimal amount, DateTime date, string note)
        {
            this.amount = amount;
            this.date = date;
            this.note = note;
        }
    }
}
