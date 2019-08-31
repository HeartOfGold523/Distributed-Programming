using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Checking
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICheckingService" in both code and config file together.
    [ServiceContract]
    public interface ICheckingService
    {
        [OperationContract]
        void AddDebit(Debit debit);

        [OperationContract]
        void AddCredit(Credit credit);

        [OperationContract]
        TransactionList GetAllTransactions();

        [OperationContract]
        TransactionList GetTransactionsByDateRange(DateTime start, DateTime end);

        [OperationContract]
        TransactionList GetCreditsByType(CreditTypeEnum creditType);

        [OperationContract]
        TransactionList GetDebitsByType(DebitTypeEnum debitType);
    }
}
