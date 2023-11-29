// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var giftCard = new GiftCardAccount("gift card", 100, 50);
giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
giftCard.PerformMonthEndTransactions();
// can make additional deposits:
giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
Console.WriteLine(giftCard.GetAccountHistory());

/*
using System;

namespace Hello { 
    class Program
    {
        static void Main() {
            Console.WriteLine(DateTime.Now.Date.ToString());
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine("Hello World");

            string str1 = Console.ReadLine();
            Console.WriteLine(str1);
            
            Console.ReadKey();
        }

    }

}
*/
