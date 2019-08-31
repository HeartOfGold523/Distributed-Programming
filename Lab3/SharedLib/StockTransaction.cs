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
    public class StockTransaction
    {
        [DataMember]
        public Stock Stock;      //Stock object
        [DataMember]
        public DateTime Time;    //Date/time of transaction
        [DataMember]
        public decimal Change;   //Amount that the stock price changed
        [DataMember]
        public int Shares;       //Number of shares traded at the new price

        public StockTransaction()
        {
            this.Stock = new Stock();
            this.Time = default;
            this.Change = default;
            this.Shares = default;
        }

        public StockTransaction(Stock stock, DateTime time, decimal change, int shares)
        {
            this.Stock = stock;
            this.Time = time;
            this.Change = change;
            this.Shares = shares;
        }

        public override string ToString()
        {
            char direction = '=';
            if (Change < 0)
            {
                direction = '\u25BC';
            }
            else if (Change > 0)
            {
                direction = '\u25B2';
            }
            return string.Format("{0:yyyy-MM-dd HH:mm:ss} {1} {2} {3,10:N2} [{4,8:N0}]",
            Time, Stock, direction, Change, Shares);
        }
    }
}
