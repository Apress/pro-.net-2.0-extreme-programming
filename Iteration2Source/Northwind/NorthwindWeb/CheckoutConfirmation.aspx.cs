using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using BusinessLayer;
using DataLayer;


public partial class CheckoutConfirmation : System.Web.UI.Page
{
    protected ShoppingCart cart = null;
    protected IDictionaryEnumerator cartEnumerator = null;
    protected decimal total = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
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

        cartEnumerator = cart.GetCartContents();
    }

    protected void CompleteOrderButton_Click(Object sender, System.EventArgs e)
    {
        // Get the current customer
        User user = (User)Session["User"];
        Customer customer = CustomerData.FindCustomerByUserName(user.UserName);

        // Create the new order
        int orderID = OrderData.InsertOrder(customer);

        // Do order Completion Stuff and redirect to OrderConfirmation Page
        cart = (ShoppingCart)Session["cart"];
        cartEnumerator = cart.GetCartContents();

        while (cartEnumerator.MoveNext())
        {
            LineItem lineItem = (LineItem)cartEnumerator.Value;

            OrderDetailData.InsertLineItem(orderID, lineItem);
            lineItem.Item.Quantity -= lineItem.Quantity;
            ProductData.UpdateQuantity(lineItem.Item);
        }

        // Empty the cart
        Session["cart"] = null;

        Response.Redirect("OrderConfirmation.aspx?orderID=" + orderID, true);
    }

    protected void CancelButton_Click(Object sender, System.EventArgs e)
    {
        Response.Redirect("DisplayShoppingCart.aspx", true);
    }
}
