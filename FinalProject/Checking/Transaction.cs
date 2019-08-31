using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    [KnownType(typeof(Credit))]
    [KnownType(typeof(Debit))]
    [DataContract]
    public class Transaction
    {
        [DataMember] //date of transaction
        public DateTime Date { get; set; }

        [DataMember] //transaction description
        public string Description { get; set; }

        [DataMember] //transaction amount (positive = deposits, negative = withdrawals)
        public decimal Amount { get; set; }
    }
}