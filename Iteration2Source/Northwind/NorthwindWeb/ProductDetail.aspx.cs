using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DataLayer;
using BusinessLayer;

public partial class ProductDetail_aspx : System.Web.UI.Page
{
    protected Product product;

    protected void Page_Load(object sender, System.EventArgs e)
    {
		string productID = Request.Params.Get("productID");

		if (productID != null)
		{
			int id = Convert.ToInt32(productID);
			product = ProductData.GetProduct(id);
		}		
    }

    protected void Button_Click(object sender, System.EventArgs e)
    {
		ShoppingCart cart = null;
		LineItem lineItem = new LineItem(1, product);

		if (Session["cart"] != null)
		{
			cart = (ShoppingCart)Session["cart"];
		}
		else
		{
			cart = new ShoppingCart();
			cart.Quantity = 0;
			Session["cart"] = cart;
		}

		cart.AddLineItem(lineItem);

		// Go to user's shopping cart
		Response.Redirect("DisplayShoppingCart.aspx", true);
	}
}
