using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace SalesImport
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            SalesDataReader salesDataReader = null;
            SalesDataWriter salesDataWriter = null;
            var logger = new Logger();
            try
            {
                salesDataReader = new SalesDataReader(config["sourceFilePath"]);
                //production : password should be encrypted
                salesDataWriter = new SalesDataWriter(config["connectionString"]);
                ImportData(salesDataReader, salesDataWriter, logger);
            }
            catch (Exception ex)
            {
                logger.WriteLogError(ex.Message);
            }
            finally
            {
                if(salesDataReader != null) salesDataReader.Dispose();
                if(salesDataWriter != null) salesDataWriter.Dispose();

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
