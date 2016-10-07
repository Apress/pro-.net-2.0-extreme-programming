#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using NUnit.Framework;
using DataLayer;
using BusinessLayer;

#endregion

namespace TestLayer
{
	[TestFixture]
	public class ProductTests
	{
		private StringBuilder connectionString;
		private int productID;
		private int categoryID;
		private string productName;
		private decimal price;
		private int quantity;

		public ProductTests()
		{
			productName = "Bogus Product";
			price = 10.00M;
			quantity = 10;
			categoryID = 4;

			// Build connection string
			connectionString = new StringBuilder("Driver={Microsoft Access Driver (*.mdb)};");
			connectionString.Append("DBQ=c:\\xpnet\\database\\Northwind.mdb");
		}

		[SetUp]
		public void Init()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString.ToString();
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("INSERT INTO Products (ProductName, ");
				commandText.Append("CategoryID, UnitPrice, ");
				commandText.Append("UnitsInStock) VALUES ('");
				commandText.Append(productName);
				commandText.Append("', ");
				commandText.Append(categoryID);
				commandText.Append(", ");
				commandText.Append(price);
				commandText.Append(", ");
				commandText.Append(quantity);
				commandText.Append(")");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the INSERT worked
				Assert.AreEqual(1, rows, "Unexpected row count, gasp!");

				// Get the ID of the category we just inserted
				// This will be used to remove the category in the TearDown
				commandText = new StringBuilder("SELECT ProductID FROM");
				commandText.Append(" Products WHERE ProductName = ");
				commandText.Append("'Bogus Product'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Make sure that we found our product
				if (dataReader.Read())
				{
					productID = dataReader.GetInt32(0);
				}

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Error: " + e.Message);
			}
		}

		[TearDown]
		public void Destroy()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = connectionString.ToString();
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("DELETE FROM Products WHERE ProductID = ");
				commandText.Append(productID);

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the DELETE worked
				Assert.AreEqual(1, rows, "Unexpected row count, gasp!");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Error: " + e.Message);
			}
		}

		[Test]
		public void TestGetProductsByCategory()
		{
			ArrayList products = ProductData.GetProductsByCategory(categoryID);
			Assert.IsNotNull(products, "GetProductsByCategory returned a null value, gasp!");
			Assert.IsTrue(products.Count > 0, "Bad Products count, gasp!");
		}

		[Test]
		public void NegativeTestGetProductsByCategory()
		{
			ArrayList products = ProductData.GetProductsByCategory(555555);
			Assert.AreEqual(0, products.Count, "Product list was not empty, gasp!");
		}

		[Test]
		public void TestGetProduct()
		{
			Product product = ProductData.GetProduct(productID);
			Assert.IsNotNull(product, "Product was null, gasp!");
			Assert.AreEqual(productID, product.ProductID, "Incorrect Product ID, gasp!");
		}

		[Test]
		public void NegativeTestGetProduct()
		{
			Product product = ProductData.GetProduct(55555);
			Assert.IsNull(product, "Product was not null, gasp!");
		}

		[Test]
		public void TestSearchForProducts()
		{
			ArrayList products = ProductData.SearchForProducts(productName);
			Assert.IsNotNull(products, "Product list was null, gasp!");
			Assert.IsTrue(products.Count > 0, "Incorrect product count, gasp!");
		}

		[Test]
		public void NegativeTestSearchForProducts()
		{
			ArrayList products = ProductData.SearchForProducts("Negative Search String");
			Assert.AreEqual(0, products.Count, "Products list was not empty, gasp!");
		}
	}
}
