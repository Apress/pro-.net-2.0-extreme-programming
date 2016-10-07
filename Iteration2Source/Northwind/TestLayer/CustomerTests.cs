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
	public class CustomerTests
	{
		private string userName;
		private string userPassword;
		private string userRole;
		private string customerID;
		private string companyName;
		private string address;
		private string city;
		private string postalCode;
		private string country;
		private string phoneNumber;

		public CustomerTests()
		{
			userName = "bogus user";
			userPassword = "bogus";
			userRole = "customer";
			customerID = "Z1Z1Z";
			companyName = "Bogus Company";
			address = "1234 Main Street";
			city = "Hometown";
			postalCode = "10001";
			country = "United States";
			phoneNumber = "303-555-1234";
		}

		[SetUp]
		public void Init()
		{
			CreateUser();
			CreateCustomer();
		}

        [Test]
        public void TestFindCustomerByCustomerID()
        {
            Customer foundCustomer = CustomerData.FindCustomerByCustomerID(customerID);

            Assert.IsNotNull(foundCustomer, "Found customer object was null, gasp!");
            Assert.AreEqual(customerID, foundCustomer.CustomerID, "Customer ID don't match, gasp!");
            Assert.AreEqual(userName, foundCustomer.UserName, "Customer user names don't match, gasp!");
            Assert.AreEqual(companyName, foundCustomer.CompanyName, "Customer company names don't match, gasp!");
            Assert.AreEqual(address, foundCustomer.Address, "Customer addresses don't match, gasp!");
            Assert.AreEqual(city, foundCustomer.City, "Customer cities don't match, gasp!");
            Assert.AreEqual(postalCode, foundCustomer.PostalCode, "Customer postal codes don't match, gasp!");
            Assert.AreEqual(country, foundCustomer.Country, "Customer countries don't match, gasp!");
            Assert.AreEqual(phoneNumber, foundCustomer.PhoneNumber, "Customer phone numbers don't match, gasp!");
        }

		[Test]
		public void TestFindCustomerByUserName()
		{
			Customer foundCustomer = CustomerData.FindCustomerByUserName(userName);

			Assert.IsNotNull(foundCustomer, "Found customer object was null, gasp!");
			Assert.AreEqual(customerID, foundCustomer.CustomerID, "Customer ID did not match, gasp!");
			Assert.AreEqual(userName, foundCustomer.UserName, "Customer user name did not match, gasp!");
			Assert.AreEqual(companyName, foundCustomer.CompanyName, "Customer company names did not match, gasp!");
			Assert.AreEqual(address, foundCustomer.Address, "Customer address did not match, gasp!");
			Assert.AreEqual(city, foundCustomer.City, "Customer city did not match, gasp!");
			Assert.AreEqual(postalCode, foundCustomer.PostalCode, "Customer postal code did not match, gasp!");
			Assert.AreEqual(country, foundCustomer.Country, "Customer country did not match, gasp!");
			Assert.AreEqual(phoneNumber, foundCustomer.PhoneNumber, "Customer phone number did not match, gasp!");
		}

		[TearDown]
		public void destroy()
		{
			RemoveCustomer();
			RemoveUser();
		}

		private void CreateUser()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("INSERT INTO Users(");
				commandText.Append("UserName, ");
				commandText.Append("Password, ");
				commandText.Append("Role) VALUES ('");
				commandText.Append(userName);
				commandText.Append("', '");
				commandText.Append(userPassword);
				commandText.Append("', '");
				commandText.Append(userRole);
				commandText.Append("')");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure that the INSERT worked
				Assert.AreEqual(1, rows, "Unexpected Users row count");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Users database error: " + e.Message);
			}
		}

		private void RemoveUser()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("DELETE FROM Users WHERE UserName = '");
				commandText.Append(userName);
				commandText.Append("'");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure the DELETE worked
				Assert.AreEqual(1, rows, "Unexpected Users row count, gasp!");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Users database error: " + e.Message);
			}
		}

		private void CreateCustomer()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("INSERT INTO Customers (");
				commandText.Append("CustomerID, ");
				commandText.Append("UserName, ");
				commandText.Append("CompanyName, ");
				commandText.Append("Address, ");
				commandText.Append("City, ");
				commandText.Append("PostalCode, ");
				commandText.Append("Country, ");
				commandText.Append("Phone) VALUES ('");
				commandText.Append(customerID);
				commandText.Append("', '");
				commandText.Append(userName);
				commandText.Append("', '");
				commandText.Append(companyName);
				commandText.Append("', '");
				commandText.Append(address);
				commandText.Append("', '");
				commandText.Append(city);
				commandText.Append("', '");
				commandText.Append(postalCode);
				commandText.Append("', '");
				commandText.Append(country);
				commandText.Append("', '");
				commandText.Append(phoneNumber);
				commandText.Append("')");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure the INSERT worked
				Assert.AreEqual(1, rows, "Unexpected Customers row count, gasp!");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Customers database error: " + e.Message);
			}
		}

		private void RemoveCustomer()
		{
			try
			{
				OdbcConnection dataConnection = new OdbcConnection();
				dataConnection.ConnectionString = DataUtilities.ConnectionString;
				dataConnection.Open();

				OdbcCommand dataCommand = new OdbcCommand();
				dataCommand.Connection = dataConnection;

				// Build command string
				StringBuilder commandText = new StringBuilder("DELETE FROM Customers WHERE CustomerID = '");
				commandText.Append(customerID);
				commandText.Append("'");

				dataCommand.CommandText = commandText.ToString();

				int rows = dataCommand.ExecuteNonQuery();

				// Make sure the DELETE worked
				Assert.AreEqual(1, rows, "Unexpected Users row count, gasp!");

				dataConnection.Close();
			}
			catch (Exception e)
			{
				Assert.Fail("Customer database error: " + e.Message);
			}
		}
	}
}
