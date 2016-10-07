#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using BusinessLayer;

#endregion

namespace DataLayer
{
	public class CustomerData
	{
		public CustomerData()
		{

		}

        public static Customer FindCustomerByCustomerID(string customerID)
        {
            Customer customer = null;
            string connString = DataUtilities.ConnectionString;

            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = connString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText =
                  new StringBuilder("SELECT * FROM Customers WHERE CustomerID = '");
                commandText.Append(customerID);
                commandText.Append("'");

                dataCommand.CommandText = commandText.ToString();

                OdbcDataReader dataReader = dataCommand.ExecuteReader();

                // Make Sure that we found our user
                if (dataReader.Read())
                {
                    customer = new Customer(dataReader.GetString(0),  // CustomerID
                      dataReader.GetString(1),                        // UserName
                      dataReader.GetString(2),                        // CompanyName
                      dataReader.GetString(5),                        // Address
                      dataReader.GetString(6),                        // City
                      dataReader.GetString(8),                        // PostalCode
                      dataReader.GetString(9),                        // Country
                      dataReader.GetString(10)                        // Phone
                      );
                }

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("error: " + e.Message);
            }

            return customer;
        }

		public static Customer FindCustomerByUserName(string userName)
		{
			Customer customer = null;

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Customers WHERE UserName = '");
				commandText.Append(userName);
				commandText.Append("'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Make sure that we found our user
				if (dataReader.Read())
				{
					customer = new Customer(dataReader.GetString(0), // CustomerID
						dataReader.GetString(1), // UserName
						dataReader.GetString(2), // CompanyName
						dataReader.GetString(5), // Address
						dataReader.GetString(6), // City
						dataReader.GetString(8), // PostalCode
						dataReader.GetString(9), // Country
						dataReader.GetString(10) // Phone
					);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("error: " + e.Message);
			}

			return customer;
		}
	}
}
