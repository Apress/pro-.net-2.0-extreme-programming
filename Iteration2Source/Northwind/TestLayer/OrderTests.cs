#region Using directives
using System;
using System.Collections;
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
    public class OrderTests
    {
        private string userName;
        private string userPassword;
        private string userRole;
        private Customer customer;
        private string customerID;
        private string companyName;
        private string address;
        private string city;
        private string postalCode;
        private string country;
        private string phoneNumber;
        private int orderID;
        private DateTime orderDate;
        private DateTime shipDate;

        public OrderTests()
        {
            userName = "bogus user";
            userPassword = "bogus";
            userRole = "customer";
            customer = null;
            customerID = "Z1Z1Z";
            companyName = "Bogus Company";
            address = "1234 Main Street";
            city = "Hometown";
            postalCode = "10001";
            country = "United States";
            phoneNumber = "303-555-1234";
            orderDate = new System.DateTime(2999, 1, 1);
            shipDate = new System.DateTime(2999, 1, 2);
            orderID = -1;
        }

        [SetUp]
        public void Init()
        {
            CreateUser();
            CreateCustomer();
        }

        [Test]
        public void TestInsertOrder()
        {
            orderID = OrderData.InsertOrder(customer);

            Assert.IsTrue(orderID > 0, "Order ID was invalid, gasp!");
        }

        [Test]
        public void TestFindOrdersByCustomerID()
        {
            ArrayList foundOrders = OrderData.FindOrdersByCustomerID(customerID);

            Assert.IsNotNull(foundOrders, "Found orders object was null, gasp!");
            Assert.IsTrue(foundOrders.Count > 0, "Orders array was empty.");

            if ((foundOrders != null) && (foundOrders.Count > 0))
            {
                Assert.AreEqual(customerID, ((Order)foundOrders[0]).CustomerID, "Customer IDs don't match, gasp!");
                Assert.AreEqual(orderDate, ((Order)foundOrders[0]).OrderDate, "Order dates don't match, gasp!");
                Assert.AreEqual(shipDate, ((Order)foundOrders[0]).ShipDate, "Ship dates don't match, gasp!");
                Assert.AreEqual(userName, ((Order)foundOrders[0]).ShipName, "User names don't match, gasp!");
                Assert.AreEqual(address, ((Order)foundOrders[0]).ShipAddress, "Address don't match, gasp!");
                Assert.AreEqual(city, ((Order)foundOrders[0]).ShipCity, "Cities don't match, gasp!");
                Assert.AreEqual(postalCode, ((Order)foundOrders[0]).ShipPostalCode, "Postal codes don't match, gasp!");
                Assert.AreEqual(country, ((Order)foundOrders[0]).ShipCountry, "Countries don't match, gasp!");
            }
        }

        [Test]
        public void TestFindOrderByOrderID()
        {
            Order foundOrder = OrderData.FindOrderByOrderID(orderID);

            Assert.IsNotNull(foundOrder, "Found order object was null, gasp!");

            if (foundOrder != null)
            {
                Assert.AreEqual(customerID, foundOrder.CustomerID, "Customer IDs don't match, gasp!");
                Assert.AreEqual(orderDate, foundOrder.OrderDate, "Order dates don't match, gasp!");
                Assert.AreEqual(shipDate, foundOrder.ShipDate, "Ship dates don't match, gasp!");
                Assert.AreEqual(userName, foundOrder.ShipName, "User names don't match, gasp!");
                Assert.AreEqual(address, foundOrder.ShipAddress, "Address don't match, gasp!");
                Assert.AreEqual(city, foundOrder.ShipCity, "Cities don't match, gasp!");
                Assert.AreEqual(postalCode, foundOrder.ShipPostalCode, "Postal codes don't match, gasp!");
                Assert.AreEqual(country, foundOrder.ShipCountry, "Countries don't match, gasp!");
            }
        }

        [TearDown]
        public void Destroy()
        {
            RemoveOrder();
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

                // Initialize new customer
                customer = new Customer(customerID,
                                        userName,
                                        companyName,
                                        address,
                                        city,
                                        postalCode,
                                        country,
                                        phoneNumber);
                Assert.IsNotNull(customer, "Newly created customer is null, gasp!");
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
                Assert.AreEqual(1, rows, "Unexpected Customer row count, gasp!");

                dataConnection.Close();

                // Free up our customer object
                customer = null;
            }
            catch (Exception e)
            {
                Assert.Fail("Customer database error: " + e.Message);
            }
        }

        private void RemoveOrder()
        {
            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("DELETE FROM Orders WHERE OrdersID = ");
                commandText.Append(orderID);

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Make sure that the DELETE worked
                Assert.AreEqual(1, rows, "Unexpected Orders row count, gasp!");

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("Orders database error: " + e.Message);
            }
        }
    }
}
