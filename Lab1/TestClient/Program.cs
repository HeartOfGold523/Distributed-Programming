using System;
using MathServiceRef;

namespace TestClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            MathServiceClient proxy = new MathServiceClient();
            double result = await proxy.AddAsync(12.5, 2.3);
            Console.WriteLine(result);

            result = await proxy.SubtractAsync(12.5, 2.3);
            Console.WriteLine(result);

            result = await proxy.MultiplyAsync(12.5, 2.3);
            Console.WriteLine(result);

            result = await proxy.DivideAsync(12.5, 2.3);
            Console.WriteLine(result);

            result = await proxy.CircleAreaAsync(2.3);
            Console.WriteLine(result);
        }
    }
}
