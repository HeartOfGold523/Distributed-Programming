using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace SharedLib
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public string Symbol; //Stock symbol, like "MSFT"
        [DataMember]
        public decimal Price; //Current trading price

        public Stock()
        {
            this.Symbol = null;
            this.Price = default;
        }

        public Stock (string symbol, decimal price)
        {
            this.Symbol = symbol;
            this.Price = price;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,10:N2}", Symbol, Price);
        }
    }
}
