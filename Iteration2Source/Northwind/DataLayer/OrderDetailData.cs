#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using BusinessLayer;
#endregion

namespace DataLayer
{
    public class OrderDetailData
    {
        public OrderDetailData()
        {
        }

        public static ArrayList FindOrderDetailsByOrderID(int orderID)
        {
            ArrayList orderDetails = new ArrayList();
            string connectionString = DataUtilities.ConnectionString;

            if ((connectionString != null) && (connectionString.Length > 0))
            {
                try
                {
                    OdbcConnection dataConnection = new OdbcConnection();
                    dataConnection.ConnectionString = connectionString;
                    dataConnection.Open();

                    OdbcCommand dataCommand = new OdbcCommand();
                    dataCommand.Connection = dataConnection;

                    // Build Command String
                    StringBuilder commandText =
                      new StringBuilder("SELECT * FROM [Orders Details] WHERE OrdersID = ");
                    commandText.Append(orderID);

                    dataCommand.CommandText = commandText.ToString();

                    OdbcDataReader dataReader = dataCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();
                        orderDetail.OrderID = dataReader.GetInt32(0);
                        orderDetail.ProductID = dataReader.GetInt32(1);
                        orderDetail.UnitPrice = dataReader.GetDecimal(2);
                        orderDetail.QuantityOrdered = dataReader.GetInt16(3);
                        orderDetail.Discount = dataReader.GetFloat(4);

                        orderDetails.Add(orderDetail);
                    }

                    dataConnection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
            }

            return orderDetails;
        }

        public static int InsertLineItem(int orderID, LineItem lineItem)
        {
            int rows = -1;

            try
            {
                Product product = lineItem.Item;
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("INSERT INTO [Orders Details] (");
                commandText.Append("OrdersID, ");
                commandText.Append("ProductID, ");
                commandText.Append("UnitPrice, ");
                commandText.Append("Quantity, ");
                commandText.Append("Discount) VALUES (");
                commandText.Append(orderID);
                commandText.Append(", ");
                commandText.Append(product.ProductID);
                commandText.Append(", ");
                commandText.Append(product.Price);
                commandText.Append(", ");
                commandText.Append(lineItem.Quantity);
                commandText.Append(", ");
                commandText.Append(0);
                commandText.Append(")");

                dataCommand.CommandText = commandText.ToString();

                rows = dataCommand.ExecuteNonQuery();

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return rows;
        }
    }
}
