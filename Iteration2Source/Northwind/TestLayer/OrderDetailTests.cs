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
    public class OrderDetailTests
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
        private int orderID;
        private DateTime orderDate;
        private DateTime shipDate;
        private int productID;
        private string productName;
        private decimal unitPrice;
        private int quantityOrdered;
        private int stockQuantity;
        private int categoryID;
        private LineItem lineItem;
        private Product product;
        private float discount;

        public OrderDetailTests()
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
            orderDate = new System.DateTime(2999, 1, 1);
            shipDate = new System.DateTime(2999, 1,2);
            productName = "bogus product";
            unitPrice = 99.95M;
            quantityOrdered = 5;
            stockQuantity = 50;
            categoryID = 3;
            lineItem = null;
            product = null;
            discount = 0;
        }

        [SetUp]
        public void Init()
        {
            CreateUser();
            CreateCustomer();
            CreateProduct();
            CreateOrder();
            CreateLineItem();
        }

        [Test]
        public void TestInsertLineItem()
        {
            int rows = OrderDetailData.InsertLineItem(orderID, lineItem);
            Assert.AreEqual(1, rows, "Unexpected OrderDetail row count, gasp!");
        }

        [Test]
        public void TestFindOrderDetailsByOrderID()
        {
            ArrayList foundOrderDetails = OrderDetailData.FindOrderDetailsByOrderID(orderID);

            Assert.IsNotNull(foundOrderDetails, "Found order details object was null, gasp!");
            Assert.IsTrue(foundOrderDetails.Count > 0, "Order Details array was empty.");

            if ((foundOrderDetails != null) && (foundOrderDetails.Count > 0))
            {
                Assert.AreEqual(orderID, ((OrderDetail)foundOrderDetails[0]).OrderID, "Order IDs don't match, gasp!");
                Assert.AreEqual(productID, ((OrderDetail)foundOrderDetails[0]).ProductID, "Product IDs don't match, gasp!");

                // This assertion is formating the unit price because without doing so, the decimal
                // expected value is 99.95 and the decimal actual value is 99.9500 for no explainable
                // reason.
                Assert.AreEqual(unitPrice.ToString("C"), ((OrderDetail)foundOrderDetails[0]).UnitPrice.ToString("C"), "Unit prices don't match, gasp!");
                Assert.AreEqual(quantityOrdered, ((OrderDetail)foundOrderDetails[0]).QuantityOrdered, "Quantities don't match, gasp!");
                Assert.AreEqual(discount, ((OrderDetail)foundOrderDetails[0]).Discount, "Discounts don't match, gasp!");
            }
        }

        [TearDown]
        public void Destroy()
        {
            RemoveOrderLineItem();
            RemoveOrder();
            RemoveProduct();
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

                // Build Command String
                StringBuilder commandText = new StringBuilder("INSERT INTO Users (");
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
                Assert.AreEqual(1, rows, "Unexpected Users row count, gasp!");

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("User database error: " + e.Message);
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
                Assert.AreEqual(1, rows, "Unexpected Customer row count, gasp!");

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("Customer database error: " + e.Message);
            }
        }

        private void CreateProduct()
        {
            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("INSERT INTO Products (");
                commandText.Append("ProductName, ");
                commandText.Append("CategoryID, ");
                commandText.Append("UnitPrice, ");
                commandText.Append("UnitsInStock) VALUES ('");
                commandText.Append(productName);
                commandText.Append("', ");
                commandText.Append(categoryID);
                commandText.Append(", ");
                commandText.Append(unitPrice);
                commandText.Append(", ");
                commandText.Append(stockQuantity);
                commandText.Append(")");

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Make sure that the INSERT worked
                Assert.AreEqual(1, rows, "Unexpected Products row count, gasp!");

                // Get the ID of the product we just inserted
                // This will be used to remove the product in the test TearDown
                commandText = new StringBuilder("SELECT ProductID FROM Products WHERE ProductName = '");
                commandText.Append(productName);
                commandText.Append("'");

                dataCommand.CommandText = commandText.ToString();

                OdbcDataReader dataReader = dataCommand.ExecuteReader();

                // Make sure that you found the product
                if (dataReader.Read())
                {
                    productID = dataReader.GetInt32(0);
                }

                dataConnection.Close();

                // Create a product
                product = new Product(productID,
                                      categoryID,
                                      productName,
                                      unitPrice,
                                      stockQuantity);
                Assert.IsNotNull(product, "Newly created Product is null, gasp!");
            }
            catch (Exception e)
            {
                Assert.Fail("Products database error : " + e.Message);
            }
        }

        public void RemoveProduct()
        {
            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("DELETE FROM Products WHERE ProductID = ");
                commandText.Append(productID);

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Make sure that the DELETE worked
                Assert.AreEqual(1, rows, "Unexpected Products row count, gasp!");

                dataConnection.Close();

                product = null;
            }
            catch (Exception e)
            {
                Assert.Fail("Products database error: " + e.Message);
            }
        }

        private void CreateOrder()
        {
            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("INSERT INTO Orders (");
                commandText.Append("CustomerID, ");
                commandText.Append("OrdersDate, ");
                commandText.Append("ShippedDate, ");
                commandText.Append("ShipName, ");
                commandText.Append("ShipAddress, ");
                commandText.Append("ShipCity, ");
                commandText.Append("ShipPostalCode, ");
                commandText.Append("ShipCountry) VALUES ('");
                commandText.Append(customerID);
                commandText.Append("', '");
                commandText.Append(orderDate);
                commandText.Append("', '");
                commandText.Append(shipDate);
                commandText.Append("', '");
                commandText.Append(userName);
                commandText.Append("', '");
                commandText.Append(address);
                commandText.Append("', '");
                commandText.Append(city);
                commandText.Append("', '");
                commandText.Append(postalCode);
                commandText.Append("', '");
                commandText.Append(country);
                commandText.Append("')");

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Make sure the INSERT worked
                Assert.AreEqual(1, rows, "Unexpected Orders row count, gasp!");

                // Get the ID of the order we just inserted
                // This will be used to remove the order in the test TearDown
                commandText = new StringBuilder("SELECT OrdersID FROM Orders WHERE CustomerID = '");
                commandText.Append(customerID);
                commandText.Append("'");

                dataCommand.CommandText = commandText.ToString();

                OdbcDataReader dataReader = dataCommand.ExecuteReader();

                // Make sure that you found the order
                if (dataReader.Read())
                {
                    orderID = dataReader.GetInt32(0);
                }

                dataConnection.Close();
            }
            catch (Exception e)
            {
                Assert.Fail("Orders database error: " + e.Message);
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

        public void CreateLineItem()
        {
            lineItem = new LineItem(quantityOrdered, product);
            Assert.IsNotNull(lineItem, "Newly create lineItem is null, gasp!");
        }

        public void RemoveOrderLineItem()
        {
            try
            {
                OdbcConnection dataConnection = new OdbcConnection();
                dataConnection.ConnectionString = DataUtilities.ConnectionString;
                dataConnection.Open();

                OdbcCommand dataCommand = new OdbcCommand();
                dataCommand.Connection = dataConnection;

                // Build Command String
                StringBuilder commandText = new StringBuilder("DELETE FROM [Orders Details] WHERE OrdersID = ");
                commandText.Append(orderID);
                commandText.Append(" and ProductID = ");
                commandText.Append(productID);

                dataCommand.CommandText = commandText.ToString();

                int rows = dataCommand.ExecuteNonQuery();

                // Make sure that the DELETE worked
                Assert.AreEqual(1, rows, "Unexpected Orders Details row count, gasp!");

                dataConnection.Close();
                lineItem = null;
            }
            catch (Exception e)
            {
                Assert.Fail("Orders Details database error: " + e.Message);
            }
        }
    }
}
