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
	public class CategoryData
	{
		private static string connectionString = "Driver={Microsoft Access Driver (*.mdb)};" +
			"DBQ=c:\\xpnet\\database\\Northwind.mdb";

		public CategoryData()
		{
		}

		public static ArrayList GetAllCategories()
		{
			ArrayList categories = new ArrayList();

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				string commandText = "SELECT * FROM Categories";
				dataCommand.CommandText = commandText;

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Iterate over the query results
				while (dataReader.Read())
				{
					Category category = new Category(dataReader.GetInt32(0),
						dataReader.GetString(1));
					categories.Add(category);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return categories;
		}
	}
}
