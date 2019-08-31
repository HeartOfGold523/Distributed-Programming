using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    [CollectionDataContract]
    public class TransactionList : List<Transaction>
    {
        public TransactionList()
        {

        }

        public TransactionList(IEnumerable<Transaction> source) : base(source)
        {

        }
    }
}