using SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace StockClient
{
    class Program
    {
        static IStockService m_Proxy = null;
        static StockMonitor m_Monitor = null;

        enum MenuChoicesEnum
        {
            Quit = 0,
            AddStock,
            GetStockQuote,
            StartMonitoring
        }
        static void Main(string[] args)
        {
            try
            {
                MenuChoicesEnum choice = MenuChoicesEnum.Quit;
                m_Monitor = new StockMonitor();
                m_Proxy = ProxyGen.GetChannel<IStockService>(m_Monitor);
                m_Proxy.Login();
                do
                {
                    Console.Clear();
                    choice = ConsoleHelpers.ReadEnum<MenuChoicesEnum>("Enter selection: ");
                    switch (choice)
                    {
                        case MenuChoicesEnum.GetStockQuote:
                            GetStockQuote();
                            break;
                        case MenuChoicesEnum.AddStock:
                            AddStock();
                            break;
                        case MenuChoicesEnum.StartMonitoring:
                            MonitorStocks();
                            break;
                    }
                    Console.Write("Press <ENTER> to continue...");
                    Console.ReadLine();
                } while (choice != MenuChoicesEnum.Quit);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred: {0}", ex.Message);
                Console.ResetColor();
            }
            finally
            {
                if (m_Proxy != null)
                {
                    m_Proxy.Logout();
                }
            }
            Console.Write("Press <ENTER> to quit...");
            Console.ReadLine();
        }

        private static void MonitorStocks()
        {
            //throw new NotImplementedException();
            Console.WriteLine("Stock monitoring has begun. Press enter to stop monitoring.");
            m_Proxy.StartTickerMonitoring();
            var x = Console.ReadLine();
            if (x == "\n")
            {
                m_Proxy.StopTickerMonitoring();
            }
        }

        private static void AddStock()
        {
            //throw new NotImplementedException();
            var symbol = ConsoleHelpers.ReadString("Enter a Stock symbol to be added: ");
            var price = ConsoleHelpers.ReadDecimal("Enter the price for this stock: ");
            try
            {
                m_Proxy.AddNewStock(symbol, price);
                Console.WriteLine("Successfully added stock.");
            }
            catch (FaultException e)
            {
                Console.WriteLine("Could not add stock: {0}", e.Reason);
            }
        }

        private static void GetStockQuote()
        {
            //throw new NotImplementedException();
            var symbol = ConsoleHelpers.ReadString("Enter a Stock symbol to get quote: ");
            try
            {
                Console.WriteLine(m_Proxy.GetStockQuote(symbol).ToString());
            }
            catch (FaultException e)
            {
                Console.WriteLine("Could not get stock quote: {0}", e.Message);
            }
        }
    }
}
