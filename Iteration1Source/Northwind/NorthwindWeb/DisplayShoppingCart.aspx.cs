using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BusinessLayer;

public partial class DisplayShoppingCart_aspx : System.Web.UI.Page
{
    protected ShoppingCart cart;
    protected LineItem lineItem;
    protected IDictionaryEnumerator cartEnumerator;

	protected void Page_Load(object sender, System.EventArgs e)
	{
      if (Session["cart"] != null)
      {
        cart = (ShoppingCart)Session["cart"];

        string productIDParam = Request.Params.Get("productID");

        if (productIDParam != null)
        {
          int productID = Convert.ToInt32(productIDParam);
          int quantity = 0;
          int availableQuantity = 0;

          string quantityParam = Request.Params.Get("quantity");
          
		  if (quantityParam.Length > 0)
          {
            quantity = Convert.ToInt32(quantityParam);

            string availableQtyParam = Request.Params.Get("availableQty");

            if (availableQtyParam.Length > 0)
            {
              availableQuantity = Convert.ToInt32(availableQtyParam);
            }
          }

          string message = "";

          if (quantity > availableQuantity)
          {
            message = "Quantity requested is more than available.";
          }
          else
          {
            cart.UpdateLineItemQuantity(productID, quantity);
          }
          cart.UpdateLineItemMessage(productID, message);
        }
      }
      else
      {
        cart = new ShoppingCart();
        cart.Quantity = 0;
        Session["cart"] = cart;
      }

      cartEnumerator = cart.GetCartContents();
	}
}
