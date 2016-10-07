using System;
using System.Drawing;
using BusinessLayer;

public partial class TopNav_ascx : System.Web.UI.UserControl
{
	protected ShoppingCart cart = null;

	protected void Page_Load(object sender, System.EventArgs e)
	{       
		if ( Session["cart"] != null )
		{
			cart = (ShoppingCart)Session["cart"];
		}
		else
		{
			cart = new ShoppingCart();
			cart.Quantity = 0;
			Session["cart"] = cart;
		}
	}
}
