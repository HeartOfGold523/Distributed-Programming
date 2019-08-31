using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLib;
using System.Numerics;
using Utilities;

namespace MathClient
{
    class Program
    {
        static IMathService m_Proxy = null;
        static int m_Tests = 250;
        static BigInteger m_StartNum = BigInteger.Parse("1234567890123456");

        private static TimeSpan TestSync()
        {
            DateTime start = DateTime.Now;
            for (BigInteger i = m_StartNum; i < m_StartNum + m_Tests; i++)
            {
                bool isPrime = m_Proxy.IsPrime(i);
                if (isPrime)
                {
                    Console.WriteLine("{0} is prime", i);
                }
            }
            DateTime end = DateTime.Now;
            return end.Subtract(start);
        }

        private static TimeSpan TestAsync()
        {
            DateTime start = DateTime.Now;
            Parallel.For(0, m_Tests, i =>
            {
                bool isPrime = m_Proxy.IsPrime(m_StartNum + i);
                if (isPrime)
                {
                    Console.WriteLine("{0} is prime", m_StartNum + i);
                }
            });
            DateTime end = DateTime.Now;
            return end.Subtract(start);
        }

        static void Main(string[] args)
        {
            m_Proxy = ProxyGen.GetChannel<IMathService>();            m_StartNum = BigInteger.Parse(ConsoleHelpers.ReadString("Please enter a start number: "));
            m_Tests = ConsoleHelpers.ReadInt("Please enter the number of tests: ");

            m_Proxy.Sqrt(m_StartNum);

            TimeSpan syncTime = TestSync();
            TimeSpan asyncTime = TestAsync();

            Console.WriteLine("Total seconds of synchronous test: {0}", syncTime.TotalSeconds);
            Console.WriteLine("Total seconds of asynchronous test: {0}", asyncTime.TotalSeconds);
        }
    }
}
