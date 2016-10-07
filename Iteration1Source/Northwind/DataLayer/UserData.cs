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
	public class UserData
	{
		private static string connectionString = "Driver={Microsoft Access Driver (*.mdb)};" +
			"DBQ=c:\\xpnet\\database\\Northwind.mdb";

		public UserData()
		{
		}

		public User GetUser(string username, string password)
		{
			User user = null;

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				//Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Users WHERE UserName = '");
				commandText.Append(username);
				commandText.Append("' AND Password = '");
				commandText.Append(password);
				commandText.Append("'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Make sure that we found our user
				if (dataReader.Read())
				{
					user = new User(dataReader.GetString(0),
						dataReader.GetString(1));
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return user;
		}
	}
}
