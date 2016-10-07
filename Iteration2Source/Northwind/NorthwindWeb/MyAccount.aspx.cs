using System;
using BusinessLayer;
using DataLayer;

public partial class MyAccount : System.Web.UI.Page
{
    protected User      user;
    protected Customer  customer;

	private void Page_Load(object sender, System.EventArgs e)
	{
	    user = (User)(Session["User"]);

        if (user != null)
        {
            customer = CustomerData.FindCustomerByUserName(user.UserName);

            if (customer != null)
            {
                Session["Customer"] = customer;
            }
        }
	}
}
