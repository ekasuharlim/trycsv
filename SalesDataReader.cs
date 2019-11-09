using System;
using Microsoft.VisualBasic.FileIO;
using System.Globalization;

namespace helloworld
{
    public class SalesDataReader : IDisposable
    {
        private TextFieldParser csvParser;

        public SalesDataReader(string dataFilePath)
        {
            OpenConnection(dataFilePath);
        }

        public bool EndOfData
        {
            get
            {
                return csvParser.EndOfData;

            }
        }

        public SalesTransaction ReadData()
        {
            var fields = csvParser.ReadFields();
            var salesTransaction = new SalesTransaction
            {
                RowId =  Convert.ToInt32(fields[0]),
                OrderId = fields[1],
                OrderDate = ConvertDataToDateTime(fields[2]),
                ShipDate = ConvertDataToDateTime(fields[3]),
                ShipMode = fields[4],
                CustomerId = fields[5],
                CustomerName = fields[6],
                Segment = fields[7],
                Country = fields[8],
                City = fields[9],
                Statey = fields[10],
                PostalCode = fields[11],
                Region = fields[12],
                ProductId = fields[13],
                Category = fields[14],
                SubCategory = fields[15],
                ProductName = fields[16],
                Sales = fields[17],
                Quantity = fields[18],
                Discount = Convert.ToDouble(fields[19]),
                Profit = Convert.ToDouble(fields[20]),
            };

            return salesTransaction;
        }

        public void Dispose()
        {
            csvParser.Close();
        }

        private void OpenConnection(string dataFilePath)
        {
            csvParser = new TextFieldParser(dataFilePath);
            csvParser.SetDelimiters(new string[] { "," });
            csvParser.HasFieldsEnclosedInQuotes = true;
            //skip header row
            csvParser.ReadFields();
        } 

        private DateTime ConvertDataToDateTime(string data)
        {
            return DateTime.ParseExact(data, "dd.MM.yy", CultureInfo.InvariantCulture);
        }       
    }
}
