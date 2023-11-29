using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ConsoleApp1
{
    public class BankAccount
    {
        public readonly List<Transaction> _allTransactions = new ();
        public decimal _minimumBalance = 0m;
        public string Owner { get; set; }

        public decimal Balance {
            get 
            {
                decimal bal = 0;
                foreach (var item in _allTransactions)
                {
                    bal += item.amount;
                }
                return bal;
            }
            set { }
        }
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Owner = name;
            _minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        public BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0) { }        
        
        public virtual void PerformMonthEndTransactions() { 
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount < 0) {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of deposit must be positive");    
            }
            var deposit = new Transaction(amount,date,note);
            _allTransactions.Add(deposit);

        }
        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            if (Balance-amount > 0m)
            {
                Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
                var deposit = new Transaction(-amount, date, note);
                _allTransactions.Add(deposit);                
                if (overdraftTransaction != null)
                {
                    _allTransactions.Add(overdraftTransaction);
                }
            }           


        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn) {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else {
                return default;
            }
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransactions)
            {
                balance += item.amount;
                report.AppendLine($"{item.date.ToShortDateString()}\t{item.amount}\t{balance}\t{item.note}");
            }

            return report.ToString();
        }

    }
}
