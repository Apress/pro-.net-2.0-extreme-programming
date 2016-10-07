using System;
using System.Collections;
using BusinessLayer;
using DataLayer;

public partial class OrderDetailView : System.Web.UI.Page
{
    protected ArrayList   orderDetails;
    protected Order       order;

	private void Page_Load(object sender, System.EventArgs e)
	{
        string  foundOrderID = Request.Params.Get("orderID");

        if (foundOrderID != null)
        {
            int orderID = Convert.ToInt32(foundOrderID);

            if (orderID > 0)
            {
                order = OrderData.FindOrderByOrderID(orderID);
                orderDetails = OrderDetailData.FindOrderDetailsByOrderID(orderID);
            }
        }
    }
}
