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
	public class ProductData
	{
		private static string connectionString = "Driver={Microsoft Access Driver (*.mdb)};" +
			"DBQ=c:\\xpnet\\database\\Northwind.mdb";

		public ProductData()
		{
		}

		public static ArrayList GetProductsByCategory(int categoryID)
		{
			ArrayList products = new ArrayList();

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Products WHERE CategoryID = ");
				commandText.Append(categoryID);
				commandText.Append(" AND UnitsInStock > 0");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				while (dataReader.Read())
				{
					Product product = new Product();
					product.ProductID = dataReader.GetInt32(0);
					product.ProductName = dataReader.GetString(1);
					product.CategoryID = dataReader.GetInt32(3);
					product.Price = dataReader.GetDecimal(5);
					product.Quantity = dataReader.GetInt16(6);

					products.Add(product);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return products;
		}

		public static Product GetProduct(int productID)
		{
			Product product = null;

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Products WHERE ProductID = ");
				commandText.Append(productID);

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				if (dataReader.Read())
				{
					product = new Product();
					product.ProductID = dataReader.GetInt32(0);
					product.ProductName = dataReader.GetString(1);
					product.CategoryID = dataReader.GetInt32(3);
					product.Price = dataReader.GetDecimal(5);
					product.Quantity = dataReader.GetInt16(6);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return product;
		}

		public static ArrayList SearchForProducts(string searchString)
		{
			ArrayList products = new ArrayList();

			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("SELECT * FROM Products WHERE ProductName LIKE '%");
				commandText.Append(searchString);
				commandText.Append("%'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				while (dataReader.Read())
				{
					Product product = new Product();
					product.ProductID = dataReader.GetInt32(0);
					product.CategoryID = dataReader.GetInt32(3);
					product.ProductName = dataReader.GetString(1);
					product.Price = dataReader.GetDecimal(5);
					product.Quantity = dataReader.GetInt16(6);
					products.Add(product);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}

			return products;
		}
	}
}
