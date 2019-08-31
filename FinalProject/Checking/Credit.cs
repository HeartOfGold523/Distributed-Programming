using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    [DataContract]
    public class Credit : Transaction
    {
        [DataMember] //type of credit being applied to account
        public CreditTypeEnum CreditType { get; set; }
    }
}