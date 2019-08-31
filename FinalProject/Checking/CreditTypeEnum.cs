using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    public enum CreditTypeEnum
    {
        [EnumMember] Unknown,
        [EnumMember] Check,
        [EnumMember] Cash,
        [EnumMember] MoneyOrder,
        [EnumMember] Wire
    }
}