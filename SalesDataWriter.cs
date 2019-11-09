using System;
using MySql.Data.MySqlClient;

namespace helloworld
{

    public class SalesDataWriter :ISalesDataWriter, IDisposable
    {
        private MySqlConnection sqlConnection;
        public SalesDataWriter(string connectionString)
        {
            sqlConnection = new MySqlConnection(connectionString);
            sqlConnection.Open();
        }

        public void WriteData(SalesTransaction salesTransaction)
        {
            try
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "INSERT INTO STORE_ORDER(" +
                                        "ORDER_ID,ORDER_DATE,SHIP_DATE,SHIP_MODE,QUANTITY," +
                                        "DISCOUNT,PROFIT,PRODUCT_ID,CUSTOMER_NAME,CATEGORY,CUSTOMER_ID)" +
                                    "VALUES(" +
                                        "@ORDER_ID,@ORDER_DATE,@SHIP_DATE,@SHIP_MODE,@QUANTITY," +
                                        "@DISCOUNT,@PROFIT,@PRODUCT_ID,@CUSTOMER_NAME,@CATEGORY,@CUSTOMER_ID)";

                cmd.Parameters.AddWithValue("@ORDER_ID",salesTransaction.OrderId);
                cmd.Parameters.AddWithValue("@ORDER_DATE",salesTransaction.OrderDate);
                cmd.Parameters.AddWithValue("@SHIP_DATE",salesTransaction.ShipDate);
                cmd.Parameters.AddWithValue("@SHIP_MODE",salesTransaction.ShipMode);
                cmd.Parameters.AddWithValue("@QUANTITY",salesTransaction.Quantity);
                cmd.Parameters.AddWithValue("@DISCOUNT",salesTransaction.Discount);
                cmd.Parameters.AddWithValue("@PROFIT",salesTransaction.Profit);
                cmd.Parameters.AddWithValue("@PRODUCT_ID",salesTransaction.ProductId);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME",salesTransaction.CustomerName);
                cmd.Parameters.AddWithValue("@CATEGORY",salesTransaction.Category);
                cmd.Parameters.AddWithValue("@CUSTOMER_ID",salesTransaction.CustomerId);

                cmd.ExecuteNonQuery();
            }catch(MySqlException ex)
            {
                var insertException  = new SalesTransactionWriteException(String.Format("Row Id {0} - OrderId {1} - {2}",
                                                        salesTransaction.RowId, salesTransaction.OrderId, ex.Message),
                                                        ex);
                throw insertException;
            }
        }

        public void Dispose()
        {
            sqlConnection.Close();
        }
    }
}