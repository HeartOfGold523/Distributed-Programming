using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Checking
{
    public enum DebitTypeEnum
    {
        [EnumMember] Unknown,
        [EnumMember] Check,
        [EnumMember] Cash,
        [EnumMember] ATM
    }
}