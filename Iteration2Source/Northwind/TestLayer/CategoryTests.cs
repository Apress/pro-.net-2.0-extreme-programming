#region Using directives

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using NUnit.Framework;
using DataLayer;

#endregion

namespace TestLayer
{
	[TestFixture]
	public class CategoryTests
	{
		private int categoryID;

		public CategoryTests()
		{
		}

		[SetUp]
		public void Init()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("INSERT INTO Categories");
				commandText.Append(" (CategoryName) VALUES ('Bogus Category')");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the INSERT worked
				Assert.AreEqual(1, rows, "Unexpected row count, gasp!");

				// Get the ID of the category we just inserted
				// This will be used to remove the category in the TearDown
				commandText = new StringBuilder("SELECT CategoryID from Categories ");
				commandText.Append("WHERE CategoryName = ");
				commandText.Append("'Bogus Category'");

				dataCommand.CommandText = commandText.ToString();

				OdbcDataReader dataReader = dataCommand.ExecuteReader();

				// Make sure that we found our bogus category
				if (dataReader.Read())
				{
					categoryID = dataReader.GetInt32(0);
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
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("DELETE FROM Categories ");
				commandText.Append("WHERE CategoryID = ");
				commandText.Append(categoryID);

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
		public void TestFindAllCategories()
		{
			ArrayList categories = CategoryData.GetAllCategories();
			Assert.IsNotNull(categories, "GetAllCategories returned a null value, gasp!");
			Assert.IsTrue(categories.Count > 0, "Bad category count, gasp!");
		}
	}
}
