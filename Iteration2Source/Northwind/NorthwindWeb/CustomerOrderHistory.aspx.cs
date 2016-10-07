using System;
using System.Collections;
using BusinessLayer;
using DataLayer;

public partial class CustomerOrderHistory : System.Web.UI.Page
{
    protected Customer  customer;
    protected ArrayList orders;

    private void Page_Load(object sender, System.EventArgs e)
	{
	    customer = (Customer)(Session["Customer"]);

        if (customer != null)
        {
            orders = OrderData.FindOrdersByCustomerID(customer.CustomerID);
        }
	}
}
