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
  public class ShoppingCartTests
  {
    private StringBuilder connectionString;
    private int productID;
    private string productName;
    private int supplierID;
    private int categoryID;
    private decimal price;
    private int quantity;
    private string message;

    public ShoppingCartTests()
    {
		productName = "Bogus Product";
		supplierID = 4;
		categoryID = 4;
		price = 10.00M;
		quantity = 10;
		message = "";
      // Build Connection String
      connectionString =
        new StringBuilder("Driver={Microsoft Access Driver (*.mdb)};");
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
        StringBuilder commandText =
          new StringBuilder("INSERT INTO Products (ProductName, SupplierID, ");
        commandText.Append("CategoryID, UnitPrice, ");
        commandText.Append("UnitsInStock) VALUES");
        commandText.Append(" ('" + productName + "', ");
        commandText.Append(supplierID + ", ");
        commandText.Append(categoryID + ", "); 
        commandText.Append(price + ", ");
        commandText.Append(quantity + ")");

        dataCommand.CommandText = commandText.ToString();
            
        int rows = dataCommand.ExecuteNonQuery();
        
        // Make sure that the INSERT worked
        Assert.AreEqual(1, rows, "Unexpected row count, gasp!");

        // Get the ID of the category we just inserted
        // This will be used to remove the category in the TearDown
        commandText =
          new StringBuilder("SELECT ProductID, CategoryID FROM Products WHERE ProductName = ");
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
      catch(Exception e)
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
        StringBuilder commandText =
          new StringBuilder("DELETE FROM Products WHERE ProductID = ");
        commandText.Append(productID);

        dataCommand.CommandText = commandText.ToString();
            
        int rows = dataCommand.ExecuteNonQuery();

        // Make sure that the DELETE worked 
        Assert.AreEqual(1, rows, "Unexpected row count, gasp!");

        dataConnection.Close();
      }
      catch(Exception e)
      {
        Assert.Fail("Error: " + e.Message);
      }
    }

    [Test]
    public void TestSingleAddProduct()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      LineItem lineItem = new LineItem(7, product);
      int count = shoppingCart.Quantity;

      shoppingCart.AddLineItem(lineItem);
      count += lineItem.Quantity;

      Assert.AreEqual(count, shoppingCart.Quantity, "Invalid number of items in cart, gasp!");
    }

    [Test]
    public void TestMultipleAddProduct()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      LineItem lineItem1 = new LineItem(4, product);
      int count = shoppingCart.Quantity;

      shoppingCart.AddLineItem(lineItem1);
      count += lineItem1.Quantity;

      LineItem lineItem2 = new LineItem(5, product);

      shoppingCart.AddLineItem(lineItem2);
      count += lineItem2.Quantity;

      Assert.AreEqual(count, shoppingCart.Quantity, "Invalid number of items in cart, gasp!");
    }

    [Test]
    public void TestGetCartContents()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      LineItem lineItem1 = new LineItem(4, product);

      shoppingCart.AddLineItem(lineItem1);

      LineItem lineItem2 = new LineItem(5, product);

      shoppingCart.AddLineItem(lineItem2);

      IDictionaryEnumerator cartEnumerator = shoppingCart.GetCartContents();
      LineItem cartLineItem = null;

      // there should be only one line item
      while (cartEnumerator.MoveNext())
      {
        cartLineItem = (LineItem)cartEnumerator.Value;
      }

      Assert.IsNotNull(cartLineItem, "There where no LineItems in the ShoppingCart, gasp!");
      Assert.AreEqual(productID, cartLineItem.Item.ProductID, "Invalid Product ID, gsap!");
    }

    [Test]
    public void NegativeTestGetCartContents()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      IDictionaryEnumerator cartEnumerator = shoppingCart.GetCartContents();

      // We are testing to ensure that the ShoppingCart is empty and
      // returns the apprpriate non-value
      Assert.IsTrue(!cartEnumerator.MoveNext(), "There where LineItems in the ShoppingCart, gasp!");
    }

    [Test]
    public void TestGetLineItem()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      LineItem lineItem1 = new LineItem(4, product);

      shoppingCart.AddLineItem(lineItem1);

      LineItem lineItem2 = new LineItem(5, product);

      shoppingCart.AddLineItem(lineItem2);

      LineItem cartLineItem = shoppingCart.GetLineItem(productID);

      Assert.IsNotNull(cartLineItem, "The LineItem was not found in the ShoppingCart, gasp!");
      Assert.AreEqual(productID, cartLineItem.Item.ProductID, "Invalid Product ID, gasp!");
    }

    [Test]
    public void NegativeTestGetLineItem()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      
      // We did not add any items in the test, therefore it should
      // return null
      LineItem cartLineItem = shoppingCart.GetLineItem(productID);

      Assert.IsNull(cartLineItem, "The LineItem was not null, gsap!");
    }

    [Test]
    public void TestUpdateLineItemQuantity()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      int newQuantity = 10;
      LineItem lineItem1 = new LineItem(4, product);

      shoppingCart.AddLineItem(lineItem1);

      LineItem lineItem2 = new LineItem(5, product);

      shoppingCart.AddLineItem(lineItem2);

      // Update the LineItem quantity of the Product with productID 
      shoppingCart.UpdateLineItemQuantity(productID, newQuantity);

      LineItem cartLineItem = shoppingCart.GetLineItem(productID);

      Assert.IsNotNull(cartLineItem, "The LineItem was not found in the ShoppingCart, gasp!");
      Assert.AreEqual(newQuantity, cartLineItem.Item.Quantity, "Invalid Product ID, gasp!");
    }

    [Test]
    public void NegativeTestUpdateLineItemQuantity()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      int newQuantity = -10;
      LineItem lineItem1 = new LineItem(4, product);

      shoppingCart.AddLineItem(lineItem1);

      LineItem lineItem2 = new LineItem(5, product);

      shoppingCart.AddLineItem(lineItem2);

      // Update the LineItem quantity of the Product with productID 
      shoppingCart.UpdateLineItemQuantity(productID, newQuantity);

      LineItem cartLineItem = shoppingCart.GetLineItem(productID);

      Assert.IsNull(cartLineItem, "The LineItem was not found in the ShoppingCart, gasp!");
    }

    [Test]
    public void TestUpdateLineItemMessage()
    {
      ShoppingCart shoppingCart = new ShoppingCart();
      Product product = ProductData.GetProduct(productID);
      LineItem lineItem1 = new LineItem(4, product);

      shoppingCart.AddLineItem(lineItem1);

      // Update the LineItem quantity of the Product with productID 
      message = "test message";
      shoppingCart.UpdateLineItemMessage(productID, message);

      LineItem cartLineItem = shoppingCart.GetLineItem(productID);

      Assert.IsNotNull(cartLineItem, "The LineItem was not found in the ShoppingCart, gasp!");
      Assert.AreEqual(message, cartLineItem.Message, "Did not get the expected message, gasp!");
    }
  }
}
