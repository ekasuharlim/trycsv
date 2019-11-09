using System;

namespace helloworld
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read csv file
            var salesDataReader = new SalesDataReader(@"/home/kiasemoto/Documents/netcore/trycsv/data/sales.csv");
            var salesDataWriter = new SalesDataWriter("Server=localhost;Database=zuhlke;Uid=newuser;Pwd=test;");
            var logger = new Logger();

            while (!salesDataReader.EndOfData)
            {
                try
                {
                    var salesTransaction = salesDataReader.ReadData();
                    salesDataWriter.WriteData(salesTransaction);
                }
                catch (SalesTransactionWriteException writeException)
                {
                    logger.WriteLogError(writeException.Message);                    
                }

            }
        }
    }
}
