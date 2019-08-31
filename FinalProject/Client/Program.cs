using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.CheckingServiceRef;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckingServiceClient proxy = new CheckingServiceClient();

            Credit credit = new Credit();
            credit.Amount = 500;
            credit.CreditType = CreditTypeEnum.Cash;
            credit.Date = DateTime.Now;
            credit.Description = "ACME";

            proxy.AddCredit(credit);

            Debit debit = new Debit();
            debit.Amount = -250;
            debit.DebitType = DebitTypeEnum.ATM;
            debit.Date = DateTime.Now;
            debit.Description = "Food";
            debit.Fee = 5;

            proxy.AddDebit(debit);

            var getTrans = proxy.GetAllTransactions();
            foreach (var i in getTrans)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            var getCreds = proxy.GetCreditsByType(CreditTypeEnum.Cash);
            foreach (var i in getCreds)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            var getDebs = proxy.GetDebitsByType(DebitTypeEnum.ATM);
            foreach (var i in getDebs)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();

            var getTransDate = proxy.GetTransactionsByDateRange(DateTime.Parse("01/01/2010"), DateTime.Parse("01/01/2020"));
            foreach (var i in getTransDate)
            {
                Console.Write(i + "\t");
            }
            Console.WriteLine();
        }
    }
}
