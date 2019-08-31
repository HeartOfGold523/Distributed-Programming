using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    [DataContract]
    public class Debit : Transaction
    {
        [DataMember] //type of debit being applied to account
        public DebitTypeEnum DebitType { get; set; }

        [DataMember] //check number, if any
        public int CheckNo { get; set; }

        [DataMember] //fee amount, if any
        public decimal Fee { get; set; }
    }
}