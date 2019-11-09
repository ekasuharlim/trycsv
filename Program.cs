using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read csv file
            var salesDataReader = new SalesDataReader();
            var logger = new Logger();
            salesDataReader.ReadData(@"/home/kiasemoto/Documents/netcore/helloworld/data/sales.csv",logger);
            //Console.WriteLine(greeting.sayHello());
        }
    }
}
