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
    public class OrderData
    {
        public OrderData()
        {
        }

        public static ArrayList FindOrdersByCustomerID(string customerID)
        {
            ArrayList orders = new ArrayList();
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
                      new StringBuilder("SELECT * FROM Orders WHERE CustomerID = '");
                    commandText.Append(customerID);
                    commandText.Append("'");

                    dataCommand.CommandText = commandText.ToString();

                    OdbcDataReader dataReader = dataCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        Order order = new Order();
                        order.OrderID = dataReader.GetInt32(0);
                        order.CustomerID = dataReader.GetString(1);
                        order.OrderDate = dataReader.GetDateTime(3);
                        order.ShipDate = dataReader.GetDateTime(5);
                        order.ShipName = dataReader.GetString(8);
                        order.ShipAddress = dataReader.GetString(9);
                        order.ShipCity = dataReader.GetString(10);
                        order.ShipPostalCode = dataReader.GetString(12);
                        order.ShipCountry = dataReader.GetString(13);

                        orders.Add(order);
                    }

                    dataConnection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("error: " + e.Message);
                }
            }

            return orders;
        }

        public static Order FindOrderByOrderID(int orderID)
        {
            Order order = null;
            string connectionString = DataUtilities.ConnectionString;

            if (orderID > 0)
            {
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
                          new StringBuilder("SELECT * FROM Orders WHERE OrdersID = ");
                        commandText.Append(orderID);

                        dataCommand.CommandText = commandText.ToString();

                        OdbcDataReader dataReader = dataCommand.ExecuteReader();

                        while (dataReader.Read())
                        {
                            order = new Order();
                            order.OrderID = dataReader.GetInt32(0);
                            order.CustomerID = dataReader.GetString(1);
                            order.OrderDate = dataReader.GetDateTime(3);
                            order.ShipDate = dataReader.GetDateTime(5);
                            order.ShipName = dataReader.GetString(8);
                            order.ShipAddress = dataReader.GetString(9);
                            order.ShipCity = dataReader.GetString(10);
                            order.ShipPostalCode = dataReader.GetString(12);
                            order.ShipCountry = dataReader.GetString(13);
                        }

                        dataConnection.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("error: " + e.Message);
                    }
                }
            }

            return order;
        }

        public static int InsertOrder(Customer customer)
        {
            DateTime date = DateTime.Now;
            int orderID = -1;

            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("INSERT INTO Orders(");
                commandText.Append("CustomerID, ");
                commandText.Append("OrdersDate, ");
                commandText.Append("ShippedDate, ");
                commandText.Append("ShipName, ");
                commandText.Append("ShipAddress, ");
                commandText.Append("ShipCity, ");
                commandText.Append("ShipPostalCode, ");
                commandText.Append("ShipCountry) VALUES ('");
                commandText.Append(customer.CustomerID);
                commandText.Append("', '");
                commandText.Append(date.ToString());
                commandText.Append("', '");
                commandText.Append(date.AddDays(3).ToString());
                commandText.Append("', '");
                commandText.Append(customer.UserName);
                commandText.Append("', '");
                commandText.Append(customer.Address);
                commandText.Append("', '");
                commandText.Append(customer.City);
                commandText.Append("', '");
                commandText.Append(customer.PostalCode);
                commandText.Append("', '");
                commandText.Append(customer.Country);
                commandText.Append("')");

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Get the ID of the order we just inserted
                // This will be used to remove the order in the test TearDown
                commandText = new StringBuilder("SELECT Max(OrdersID) FROM Orders");

                dataCommand.CommandText = commandText.ToString();

                OdbcDataReader dataReader = dataCommand.ExecuteReader();

                // Make sure that you found the user
                if (dataReader.Read())
                {
                    orderID = dataReader.GetInt32(0);
                }

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }

            return orderID;
        }
    }
}
