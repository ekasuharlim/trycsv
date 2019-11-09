using System;

namespace SalesImport
{
    class Program
    {
        static void Main(string[] args)
        {

            //Read csv file
            var salesDataReader = new SalesDataReader(@"/home/kiasemoto/Documents/netcore/trycsv/data/sales.csv");
            //password should be encrypted
            var salesDataWriter = new SalesDataWriter("Server=localhost;Database=zuhlke;Uid=newuser;Pwd=test;");
            var logger = new Logger();
            try
            {
                ImportData(salesDataReader,salesDataWriter,logger);

            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
            }
            finally 
            {
                salesDataReader.Dispose();
                salesDataWriter.Dispose(); 

            }

        }

        static void ImportData(ISalesDataReader salesDataReader, ISalesDataWriter salesDataWriter, ILogger logger)
        {
            while (!salesDataReader.IsEndOfData())
            {
                try
                {
                    var salesTransaction = salesDataReader.ReadData();
                    salesDataWriter.WriteData(salesTransaction);
                }
                catch (SalesTransactionDataConversionException conversionException)
                {
                    logger.WriteLogError(conversionException.Message);
                }
                catch (SalesTransactionWriteException writeException)
                {
                    logger.WriteLogError(writeException.Message);
                }

            }

        }
    }
}
