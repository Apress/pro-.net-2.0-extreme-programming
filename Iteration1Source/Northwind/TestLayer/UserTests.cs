#region Using directives

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Text;
using NUnit.Framework;
using BusinessLayer;
using DataLayer;

#endregion

namespace TestLayer
{
	[TestFixture]
	public class UserTests
	{
		private StringBuilder connectionString;

		public UserTests()
		{
			// Build connection string
			connectionString = new StringBuilder("Driver={Microsoft Access Driver (*.mdb)}");
			connectionString.Append(";DBQ=c:\\xpnet\\database\\Northwind.mdb");
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
				StringBuilder commandText = new StringBuilder("INSERT INTO Users (UserName, Password)");
				commandText.Append(" VALUES ('bogususer', 'password')");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the INSERT worked
				Assert.AreEqual(1, rows, "Unexpected row count returned.");

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
				StringBuilder commandText = new StringBuilder("DELETE FROM Users WHERE");
				commandText.Append(" username = 'bogususer'");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the DELETE worked
				Assert.AreEqual(1, rows, "Unexpected row count returned.");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Error: " + e.Message);
			}
		}

		[Test]
		public void TestGetUser()
		{
			UserData userData = new UserData();

			Assert.IsNotNull(userData.GetUser("bogususer", "password"), "GetUser returned a null value, gasp!");
		}

		[Test]
		public void NegativeTestGetUser()
		{
			UserData userData = new UserData();

			Assert.IsNull(userData.GetUser("", ""), "GetUser did not return a null value, gasp!");
		}
	}
}
