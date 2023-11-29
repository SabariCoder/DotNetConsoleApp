using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LineOfCreditAccount : BankAccount
    {
        public LineOfCreditAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public LineOfCreditAccount(string name, decimal initialBalance, decimal minimumBalance) : base(name, initialBalance, minimumBalance)
        {
        }
    }
}
