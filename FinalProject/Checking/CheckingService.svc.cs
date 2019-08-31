using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Checking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CheckingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CheckingService.svc or CheckingService.svc.cs at the Solution Explorer and start debugging.
    public class CheckingService : ICheckingService
    {
        public void AddCredit(Credit credit)
        {
            var data = DataStore.LoadData();
            data.Add(credit);
            DataStore.SaveData();
        }

        public void AddDebit(Debit debit)
        {
            var data = DataStore.LoadData();
            data.Add(debit);
            DataStore.SaveData();
        }

        public TransactionList GetAllTransactions()
        {
            var data = DataStore.LoadData();

            var creditQuery = from trans in data
                         let credit = trans as Credit
                         where credit != null
                         orderby credit.Date, credit.Amount, credit.Description
                         select credit as Transaction;

            var debitQuery = from trans in data
                         let debit = trans as Debit
                         where debit != null
                         orderby debit.Date, debit.Amount, debit.Description
                         select debit as Transaction;

            return new TransactionList(creditQuery.Union(debitQuery));
        }

        public TransactionList GetCreditsByType(CreditTypeEnum creditType)
        {
            var data = DataStore.LoadData();

            var query = from trans in data
                        let credit = trans as Credit
                        where credit != null && credit.CreditType == creditType
                        orderby credit.Date, credit.Amount, credit.Description
                        select credit;

            return new TransactionList(query);
        }

        public TransactionList GetDebitsByType(DebitTypeEnum debitType)
        {
            var data = DataStore.LoadData();

            var query = from trans in data
                        let debit = trans as Debit
                        where debit != null && debit.DebitType == debitType
                        orderby debit.Date, debit.Amount, debit.Description
                        select debit;

            return new TransactionList(query);
        }

        public TransactionList GetTransactionsByDateRange(DateTime start, DateTime end)
        {
            var data = DataStore.LoadData();

            var creditQuery = from trans in data
                              let credit = trans as Credit
                              where credit != null && credit.Date >= start && credit.Date <= end
                              orderby credit.Date, credit.Amount, credit.Description
                              select credit as Transaction;

            var debitQuery = from trans in data
                             let debit = trans as Debit
                             where debit != null && debit.Date >= start && debit.Date <= end
                             orderby debit.Date, debit.Amount, debit.Description
                             select debit as Transaction;

            return new TransactionList(creditQuery.Union(debitQuery));
        }
    }
}
