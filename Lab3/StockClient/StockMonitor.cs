using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockClient
{
    public class StockMonitor : IStockCallback
    {
        public void StockUpdated(StockTransaction tx)
        {
            //throw new NotImplementedException();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (tx.Change < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (tx.Change > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine(tx);
            Console.ResetColor();
        }
    }
}
