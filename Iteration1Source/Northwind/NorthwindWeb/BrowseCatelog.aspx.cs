using System;
using System.Collections;
using System.ComponentModel;
using DataLayer;
using BusinessLayer;

public partial class BrowseCatelog_aspx : System.Web.UI.Page
{
	protected ArrayList products;
	protected Product product;

    protected void Page_Load(object sender, System.EventArgs e)
    {
        string categoryID = Request.Params.Get("categoryID");

        if (categoryID != null)
        {
            int id = Convert.ToInt32(categoryID);
            products = ProductData.GetProductsByCategory(id);
        }
    }
}
